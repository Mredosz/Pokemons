using Pokemons.client.pokemon.client.contract.pokemon;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class PokemonMapper : IMap<PokemonDto, Pokemon>
{
    public Pokemon ToEntity(PokemonDto dto)
    {
        return new Pokemon()
        {
            Height = dto.Height,
            Weight = dto.Weight,
            SourceId = dto.SourceId,
            Name = dto.Name
        };
    }
}