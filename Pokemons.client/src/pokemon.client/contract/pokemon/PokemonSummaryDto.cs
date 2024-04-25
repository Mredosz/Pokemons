using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.pokemon;

public class PokemonSummaryDto
{
    [JsonProperty("name")]
    public string Name { get; set; }
}