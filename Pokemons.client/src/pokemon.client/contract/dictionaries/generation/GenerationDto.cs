using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Pokemons.client.pokemon.client.contract.dictionaries.ability;
using Pokemons.client.pokemon.client.contract.pokemon;

namespace Pokemons.client.pokemon.client.contract.dictionaries.generation;

public class GenerationDto : GenerationSummaryDto
{
    [JsonProperty("id")]
    public int SourceId { get; set; }
    [JsonProperty("pokemon_species")]
    public List<PokemonSummaryDto> Pokemons { get; set; }
    [JsonProperty("abilities")]
    public List<AbilitySummaryDto> Abilities { get; set; }
}