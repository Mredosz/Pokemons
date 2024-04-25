using Newtonsoft.Json;
using Pokemons.client.pokemon.client.contract.pokemon;

namespace Pokemons.client.pokemon.client.contract.dictionaries.type;

public class TypeDto : TypeSummaryDto
{
    [JsonProperty("id")]
    public int SourceId { get; set; }
    [JsonProperty("pokemon")]
    public List<PokemonFromTypeDto> Pokemon { get; set; }

    public class PokemonFromTypeDto
    {
        [JsonProperty("pokemon")]
        public PokemonSummaryDto Pokemon { get; set; }
    }
}