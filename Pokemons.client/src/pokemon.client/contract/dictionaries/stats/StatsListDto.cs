using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.stats;

public class StatsListDto
{
    [JsonProperty("results")]
    public List<StatsSummaryDto> Stats { get; set; }
}