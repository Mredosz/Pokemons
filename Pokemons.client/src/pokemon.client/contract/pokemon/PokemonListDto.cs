using Newtonsoft.Json;

namespace Pokemons.client.pokemon.client.contract.pokemon;

public class PokemonListDto
{
    [JsonProperty("results")]
    public List<PokemonSummaryDto> Pokemons { get; set; }
}