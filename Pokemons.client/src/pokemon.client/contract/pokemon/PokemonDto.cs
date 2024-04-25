using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Pokemons.client.pokemon.client.contract.dictionaries.ability;
using Pokemons.client.pokemon.client.contract.dictionaries.stats;
using Pokemons.client.pokemon.client.contract.dictionaries.type;

namespace Pokemons.client.pokemon.client.contract.pokemon;

public class PokemonDto : PokemonSummaryDto
{
    [JsonProperty("id")]
    public int SourceId { get; set; }
    [JsonProperty("height")]
    public int Height { get; set; }
    [JsonProperty("weight")]
    public int Weight { get; set; }
    [JsonProperty("sprites")]
    public ImageSummaryDto Image { get; set; }
    [JsonProperty("abilities")]
    public List<AbilityFromPokemonDto> Abilities { get; set; }
    [JsonProperty("types")]
    public List<TypeFromPokemonDto> Types { get; set; }
    [JsonProperty("stats")]
    public List<StatsFromPokemonDto> Stats { get; set; }

    public class AbilityFromPokemonDto
    {
        [JsonProperty("slot")]
        public int Slot { get; set; }
        [JsonProperty("ability")]
        public AbilitySummaryDto Ability { get; set; }
    }

    public class ImageSummaryDto
    {
        [JsonProperty("front_default")]
        public string Url { get; set; }
    }

    public class StatsFromPokemonDto
    {
        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }
        [JsonProperty("effort")]
        public int Effort { get; set; }
        [JsonProperty("stat")]
        public StatsSummaryDto Stats { get; set; }
    }

    public class TypeFromPokemonDto
    {
        [JsonProperty("slot")]
        public int Slot { get; set; }
        [JsonProperty("type")]
        public TypeSummaryDto Type { get; set; }
    }
}