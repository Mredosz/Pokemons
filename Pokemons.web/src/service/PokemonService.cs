using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Pokemons.data;
using Pokemons.data.model;
using Pokemons.web.contract;
using Stats = Pokemons.web.contract.Stats;

namespace Pokemons.web.service;

public class PokemonService : IPokemonService
{
    private DbPokemonContext _db;
    private IMemoryCache _memoryCache;
    public string CacheKey = "pokemons";

    public PokemonService(DbPokemonContext db, IMemoryCache memoryCache)
    {
        _db = db;
        _memoryCache = memoryCache;
    }

    public List<PokemonSummaryDto> GetAllPokemons()
    {
        List<PokemonSummaryDto> pokemons;
        if (!_memoryCache.TryGetValue(CacheKey, out pokemons))
        {
            pokemons = new List<PokemonSummaryDto>();
            MapPokemonList(pokemons);

            _memoryCache.Set(CacheKey, pokemons,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(10)));
        }
        return pokemons;
    }

    private void MapPokemonList(List<PokemonSummaryDto> pokemons)
    {
        var pokemonEntities = _db?.Pokemon?.Include(p => p.Image).ToList();
        if (pokemonEntities != null)
        {
            foreach (var pokemon in pokemonEntities)
            {
                if (pokemon != null && pokemon.Image != null)
                {
                    pokemons.Add(new PokemonSummaryDto
                    {
                        Id = pokemon.Id,
                        Name = pokemon.Name,
                        Image = pokemon.Image.Url
                    });
                }
            }
        }
    }

    public PokemonDto GetPokemonById(int id)
    {
        string cacheKey = $"pokemon-{id}";
        if (!_memoryCache.TryGetValue(cacheKey, out PokemonDto pokemon))
        {
            var pokemonQuery = _db.Pokemon.AsQueryable();
            var pokemonWithAbilities = pokemonQuery
                .Include(pokemon => pokemon.Abilities)
                .ThenInclude(ability => ability.Ability);
            var pokemonWithGeneration = pokemonWithAbilities
                .Include(pokemon => pokemon.Generation);
            var pokemonWithImage = pokemonWithGeneration
                .Include(pokemon => pokemon.Image);
            var pokemonWithStats = pokemonWithImage
                .Include(pokemon => pokemon.Stats)
                .ThenInclude(stat => stat.Stats);
            var pokemonWithTypes = pokemonWithStats
                .Include(pokemon => pokemon.Types)
                .ThenInclude(type => type.Type);
            var pokemonFromDb = pokemonWithTypes
                .FirstOrDefault(pokemon => pokemon.Id == id);

            pokemon = MapPokemonById(pokemonFromDb);

            _memoryCache.Set(cacheKey, pokemon,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }

        return pokemon;
    }

    private static PokemonDto MapPokemonById(Pokemon? pokemonFromDb)
    {
        return new PokemonDto
        {
            Id = pokemonFromDb.Id,
            Name = pokemonFromDb.Name,
            Image = pokemonFromDb.Image.Url,
            Height = pokemonFromDb.Height,
            Weight = pokemonFromDb.Weight,
            Abilities = pokemonFromDb.Abilities.Select(a => a.Ability.Name).ToList(),
            Stats = pokemonFromDb.Stats.Select(s => new Stats
            {
                Name = s.Stats.Name,
                BaseStat = s.BaseStat
            }).ToList(),
            Types = pokemonFromDb.Types.Select(t => t.Type.Name).ToList(),
            Generation = pokemonFromDb.Generation.Name
        };
    }
}