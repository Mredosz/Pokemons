using Newtonsoft.Json;
using Pokemons.client.pokemon.client.contract.dictionaries.generation;
using Pokemons.client.pokemon.client.contract.pokemon;

namespace Pokemons.client.pokemon.client.contract.dictionaries.ability;
public class AbilityDto : AbilitySummaryDto
{
    [JsonProperty("id")]
    public int SourceId { get; set; }
    [JsonProperty("generation")]
    public GenerationSummaryDto Generation { get; set; }
    [JsonProperty("pokemon")]
    public List<PokemonFromAbilityDto> Pokemon { get; set; }

    public class PokemonFromAbilityDto
    {
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }
        [JsonProperty("pokemon")]
        public PokemonSummaryDto Pokemon { get; set; }
    }
}