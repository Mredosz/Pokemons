using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.type;

public class TypeListDto
{
    [JsonProperty("results")]
    public List<TypeSummaryDto> Types { get; set; }
}