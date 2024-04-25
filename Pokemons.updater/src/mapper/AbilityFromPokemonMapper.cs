using Pokemons.client.pokemon.client.contract.pokemon;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class AbilityFromPokemonMapper : IMap<PokemonDto.AbilityFromPokemonDto, AbilityFromPokemon>
{
    public AbilityFromPokemon ToEntity(PokemonDto.AbilityFromPokemonDto dto)
    {
        return new AbilityFromPokemon
        {
            Slot = dto.Slot
        };
    }
}