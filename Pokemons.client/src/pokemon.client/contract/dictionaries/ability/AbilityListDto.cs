using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.dictionaries.ability;

public class AbilityListDto
{
    [JsonProperty("results")]
    public List<AbilitySummaryDto> Abilities { get; set; }
}