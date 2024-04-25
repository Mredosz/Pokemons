using Microsoft.EntityFrameworkCore;
using Pokemons.client.pokemon.client.contract;
using Pokemons.client.pokemon.client.contract.dictionaries;
using Pokemons.client.pokemon.client.contract.dictionaries.ability;
using Pokemons.client.pokemon.client.contract.dictionaries.generation;
using Pokemons.client.pokemon.client.contract.dictionaries.stats;
using Pokemons.client.pokemon.client.contract.dictionaries.type;
using Pokemons.client.pokemon.client.contract.pokemon;
using Pokemons.data;
using Pokemons.data.model;
using Pokemons.updater.mapper;

namespace Pokemons.updater.service;

public class PokemonUpdaterService : IPokemonUpdaterService
{
    private Mapper _mapp;
    private IPokemonDictionariesClient _dictionariesClient;

    private IPokemonClient _client;

    private DbPokemonContext _db;
    public PokemonUpdaterService(Mapper mapper, IPokemonDictionariesClient dictionariesClient, IPokemonClient client,
        DbPokemonContext db)
    {
        _mapp = mapper;
        _dictionariesClient = dictionariesClient;
        _client = client;
        _db = db;
    }

    public void Update(int quantity)
    {
        UpdateDictionaries();
        UpdatePokemon(quantity);
    }

    private void UpdateDictionaries()
    {
        if (_db.Generations.Count() < 9) GetGenerationDtoList().ForEach(SaveGeneration);
        if (_db.Types.Count() < 20) GetTypeDtoList().ForEach(SaveType);
        if (_db.Abilities.Count() < 367) GetAbilityDtoList().ForEach(SaveAbility);
        if (_db.Stats.Count() < 8) _dictionariesClient.GetStats().ForEach(SaveStats);
    }
    private List<GenerationDto> GetGenerationDtoList()
    {
        var generationDtoList = new List<GenerationDto>();
        _dictionariesClient.GetGenerations().ForEach(
            generation => generationDtoList
                .Add(_dictionariesClient.GetGeneration(generation.Name)));
        return generationDtoList;
    }
    
    private void SaveGeneration(GenerationDto generationDto)
    {
        var generation = _mapp.Generation.ToEntity(generationDto);
        var generationFromDb = !_db.Generations.Any(g => g.Name == generationDto.Name);
        if (generationFromDb)
        {
            _db.Generations.Add(generation);
            _db.SaveChanges();
        }
    }
    
    private List<TypeDto> GetTypeDtoList()
    {
        var typesDtoList = new List<TypeDto>();
        _dictionariesClient.GetTypes().ForEach(
            type => typesDtoList
                .Add(_dictionariesClient.GetType(type.Name)));
        return typesDtoList;
    }
    
    private void SaveType(TypeDto typeDto)
    {
        var type = _mapp.Type.ToEntity(typeDto);
        var typeFromDb = !_db.Types.Any(g => g.Name == typeDto.Name);
        if (typeFromDb)
        {
            _db.Types.Add(type);
            _db.SaveChanges();
        }
    }
    
    private List<AbilityDto> GetAbilityDtoList()
    {
        var abilityDtoList = new List<AbilityDto>();
        _dictionariesClient.GetAbilities().ForEach(
            ability => abilityDtoList
                .Add(_dictionariesClient.GetAbility(ability.Name)));
        return abilityDtoList;
    }
    
    private void SaveAbility(AbilityDto abilityDto)
    {
        var generationFromDb = _db.Generations.ToList();
        var ability = _mapp.Ability.ToEntity(abilityDto);
        var abilityFromDb = !_db.Abilities.Any(g => g.Name == abilityDto.Name);
        ability.Generation = generationFromDb.FirstOrDefault(g => g.Name == abilityDto.Generation.Name);
        if (abilityFromDb)
        {
            _db.Abilities.Add(ability);
            _db.SaveChanges();
        }
    }
    
    private void SaveStats(StatsSummaryDto statsSummaryDto)
    {
        var stats = _mapp.Stats.ToEntity(statsSummaryDto);
        var statsFromDb = !_db.Stats.Any(g => g.Name == statsSummaryDto.Name);
        if (statsFromDb)
        {
            _db.Stats.Add(stats);
            _db.SaveChanges();
        }
    }

    private List<PokemonDto> GetPokemonDtoList(int quantity, int nextId)
    {
        var pokemonDtoList = new List<PokemonDto>();
        _client.GetPokemons(quantity, nextId)
            .ForEach(p =>
                pokemonDtoList.Add(_client.GetPokemon(p.Name)));
        return pokemonDtoList;
    }
    
    private void SavePokemon(PokemonDto pokemonDto)
    {
        var pokemon = _mapp.Pokemon.ToEntity(pokemonDto);
        var pokemonFromDb = !_db.Pokemon.Any(g => g.Name == pokemonDto.Name);
        if (pokemonFromDb)
        {
            SetRelationsToPokemon(pokemonDto, pokemon);
        }
    }

    private void SetRelationsToPokemon(PokemonDto pokemonDto, Pokemon pokemon)
    {
        pokemonDto.Types.ForEach(SaveTypeFromPokemon);
        pokemonDto.Abilities.ForEach(SaveAbilityFromPokemon);
        pokemonDto.Stats.ForEach(SaveStatsFromPokemon);
        SetAbilityRelation(pokemonDto, pokemon);
        SetTypeRelation(pokemonDto, pokemon);
        SetStatRelation(pokemonDto, pokemon);
        SaveGenerationToPokemon(pokemon);
        _db.Pokemon.Add(pokemon);
        _db.SaveChanges();
        SaveImage(pokemonDto, pokemon);
    }

    private void SaveTypeFromPokemon(PokemonDto.TypeFromPokemonDto typeFromPokemonDto)
    {
        var type = _mapp.TypeFromPokemon.ToEntity(typeFromPokemonDto);
        var typeFromDb = _db.Types.FirstOrDefault(g => g.Name == typeFromPokemonDto.Type.Name);
        if (typeFromDb != null) type.Type = typeFromDb;
        var typeFromDbInPokemon = !_db.TypeFromPokemon
            .Any(g => g.Type.Name == typeFromPokemonDto.Type.Name
            && g.Slot == typeFromPokemonDto.Slot);
        if (typeFromDbInPokemon)
        {
            _db.TypeFromPokemon.Add(type);
            _db.SaveChanges();
        }
    }

    private void SaveAbilityFromPokemon(PokemonDto.AbilityFromPokemonDto abilityFromPokemonDto)
    {
        var ability = _mapp.AbilityFromPokemon.ToEntity(abilityFromPokemonDto);
        var abiltyFromDb = _db.Abilities.FirstOrDefault(g => g.Name == abilityFromPokemonDto.Ability.Name);
        if (abiltyFromDb != null) ability.Ability = abiltyFromDb;
        var abilityFromDbInPokemon = !_db.AbilityFromPokemon
            .Any(g => g.Ability.Name == abilityFromPokemonDto.Ability.Name
                      && g.Slot == abilityFromPokemonDto.Slot);
        if (abilityFromDbInPokemon)
        {
            _db.AbilityFromPokemon.Add(ability);
            _db.SaveChanges();
        }
    }

    private void SaveStatsFromPokemon(PokemonDto.StatsFromPokemonDto statsFromPokemonDto)
    {
        var stat = _mapp.StatsFromPokemon.ToEntity(statsFromPokemonDto);
        var statFromDb = _db.Stats.FirstOrDefault(g => g.Name == statsFromPokemonDto.Stats.Name);
        if (statFromDb != null) stat.Stats = statFromDb;
        var statFromDbInPokemon = !_db.StatsFromPokemon
            .Any(g => g.Stats.Name == statsFromPokemonDto.Stats.Name
                      && g.BaseStat == statsFromPokemonDto.BaseStat);
        if (statFromDbInPokemon)
        {
            _db.StatsFromPokemon.Add(stat);
            _db.SaveChanges();
        }
    }

    private void SetAbilityRelation(PokemonDto pokemonDto, Pokemon pokemon)
    {
        foreach (var abilityFromDb in _db.AbilityFromPokemon
                     .Include(typesAbilityFromPokemon => typesAbilityFromPokemon.Ability).ToList())
        {
            foreach (var abilityFromPokemon in pokemonDto.Abilities)
            {
                if (abilityFromDb.Ability.Name.Equals( abilityFromPokemon.Ability.Name) && abilityFromDb.Slot.Equals(abilityFromPokemon.Slot))
                {
                    pokemon.Abilities?.Add(abilityFromDb);
                    abilityFromDb.Pokemons.Add(pokemon);
                }
            }
        }
    }

    private void SetTypeRelation(PokemonDto pokemonDto, Pokemon pokemon)
    {
        foreach (var typeFromDb in _db.TypeFromPokemon.Include(typesTypeFromPokemon => typesTypeFromPokemon.Type).ToList())
        {
            foreach (var typeFromPokemon in pokemonDto.Types)
            {
                if (typeFromDb.Type.Name == typeFromPokemon.Type.Name && typeFromDb.Slot == typeFromPokemon.Slot)
                {
                    pokemon.Types.Add(typeFromDb);
                    typeFromDb.Pokemons.Add(pokemon);
                }
            }
        }
    }

    private void SetStatRelation(PokemonDto pokemonDto, Pokemon pokemon)
    {
        foreach (var statFromDb in _db.StatsFromPokemon.Include(typesStatsFromPokemon => typesStatsFromPokemon.Stats).ToList())
        {
            foreach (var statFromPokemon in pokemonDto.Stats)
            {
                if (statFromDb.Stats.Name == statFromPokemon.Stats.Name && statFromDb.BaseStat == statFromPokemon.BaseStat)
                {
                    pokemon.Stats.Add(statFromDb);
                    statFromDb.Pokemons.Add(pokemon);
                }
            }
        }
    }

    private void SaveGenerationToPokemon(Pokemon pokemon)
    {
        foreach (var generationDto in GetGenerationDtoList())
        {
            foreach (var pokemonFromGeneration in generationDto.Pokemons)
            {
                foreach (var generationFromDb in _db.Generations.ToList())
                {
                    if (generationDto.Name == generationFromDb.Name && pokemonFromGeneration.Name == pokemon.Name)
                    {
                        pokemon.Generation = generationFromDb;
                    }
                }
            }
        }
    }

    private void SaveImage(PokemonDto pokemonDto, Pokemon pokemon)
    {
        var image = _mapp.Image.ToEntity(pokemonDto.Image);
        var imageFRomDb = !_db.Images.Any(g => g.Url == pokemonDto.Image.Url);
        if (imageFRomDb && image.Url != null)
        {
            _db.Images.Add(image);
            pokemon.Image = image;
            image.Pokemon = pokemon;
            _db.SaveChanges();
        }else if (imageFRomDb && image.Url == null)
        {
            image.Url = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + pokemonDto.SourceId + ".png";
            _db.Images.Add(image);
            _db.SaveChanges();
        }
    }

    private void UpdatePokemon(int quantity)
    {
        var theLastId = _db.Pokemon.Count();
        GetPokemonDtoList(quantity, theLastId).ForEach(SavePokemon);
    }
}