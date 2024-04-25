using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.generation;

public class GenerationSummaryDto
{
    [JsonProperty("name")]
    public string Name { get; set; }
}