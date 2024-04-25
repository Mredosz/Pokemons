using Pokemons.client.pokemon.client.contract.dictionaries.generation;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class GenerationMapper : IMap<GenerationDto, Generation>
{
    public Generation ToEntity(GenerationDto dto)
    {
        return new Generation()
        {
            Name = dto.Name,
            SourceId = dto.SourceId
        };
    }
}