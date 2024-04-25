using Microsoft.EntityFrameworkCore;
using Pokemons.data;
using Pokemons.web.contract;

namespace Pokemons.web.service;

public class PokemonService : IPokemonService
{
    private DbPokemonContext _db;

    public PokemonService(DbPokemonContext db)
    {
        _db = db;
    }

    public List<PokemonSummaryDto> GetAllPokemons()
    {
        List<PokemonSummaryDto> pokemons = new List<PokemonSummaryDto>();
        foreach (var pokemon in _db.Pokemon.Include(p => p.Image).ToList())
        {
            pokemons.Add(new PokemonSummaryDto
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                Image = pokemon.Image.Url
            });
        }
        return pokemons;
    }

    public PokemonDto GetPokemonById(int id)
    {
        var pokemonFromDb = _db.Pokemon
            .Include(p =>p.Abilities)
            .ThenInclude(p => p.Ability)
            .Include(p => p.Generation)
            .Include(p => p.Image)
            .Include(p => p.Stats)
            .ThenInclude(p => p.Stats)
            .Include(p => p.Types)
            .ThenInclude(p => p.Type)
            .FirstOrDefault(p => p.Id == id);
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