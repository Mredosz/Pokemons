using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.type;

public class TypeSummaryDto
{
    [JsonProperty("name")]
    public string Name { get; set; }
}