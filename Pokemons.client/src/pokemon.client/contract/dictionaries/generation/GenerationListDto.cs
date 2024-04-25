using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.generation;

public class GenerationListDto
{
    [JsonProperty("results")]
    public List<GenerationSummaryDto> Generations { get; set; }
}