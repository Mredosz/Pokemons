using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.ability;

public class AbilitySummaryDto
{
    [JsonProperty("name")]
    public string Name { get; set; }
}