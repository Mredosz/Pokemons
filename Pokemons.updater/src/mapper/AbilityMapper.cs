using Pokemons.client.pokemon.client.contract.dictionaries.ability;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class AbilityMapper : IMap<AbilityDto, Ability>
{
    public Ability ToEntity(AbilityDto dto)
    {
        return new Ability()
        {
            Name = dto.Name,
            SourceId = dto.SourceId
        };
    }
}