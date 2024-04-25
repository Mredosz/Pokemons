using Pokemons.client.pokemon.client.contract.dictionaries.type;
using Type = Pokemons.data.model.Type;

namespace Pokemons.updater.mapper;

public class TypeMapper : IMap<TypeDto, data.model.Type>
{
    public Type ToEntity(TypeDto dto)
    {
        return new Type()
        {
            Name = dto.Name,
            SourceId = dto.SourceId
        };
    }
}