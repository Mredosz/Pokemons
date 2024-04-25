using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.stats;

public class StatsSummaryDto
{
    [JsonProperty("name")]
    public string Name { get; set; }
}