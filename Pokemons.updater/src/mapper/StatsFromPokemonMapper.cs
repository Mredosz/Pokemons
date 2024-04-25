using Pokemons.client.pokemon.client.contract.pokemon;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class StatsFromPokemonMapper : IMap<PokemonDto.StatsFromPokemonDto, StatsFromPokemon>
{
    public StatsFromPokemon ToEntity(PokemonDto.StatsFromPokemonDto dto)
    {
        return new StatsFromPokemon()
        {
            BaseStat = dto.BaseStat,
            Effort = dto.Effort,
        };
    }
}