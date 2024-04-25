using Pokemons.client.pokemon.client.contract.dictionaries.stats;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class StatsMapper : IMap<StatsSummaryDto, Stats>
{
    public Stats ToEntity(StatsSummaryDto dto)
    {
        return new Stats()
        {
            Name = dto.Name
        };
    }
}