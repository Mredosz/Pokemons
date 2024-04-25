using Pokemons.client.pokemon.client.contract.pokemon;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class TypeFromPokemonMapper : IMap<PokemonDto.TypeFromPokemonDto, TypeFromPokemon>
{
    public TypeFromPokemon ToEntity(PokemonDto.TypeFromPokemonDto dto)
    {
        return new TypeFromPokemon()
        {
            Slot = dto.Slot
        };
    }
}