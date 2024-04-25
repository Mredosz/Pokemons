using System.Net;
using Newtonsoft.Json;
using Pokemons.client.pokemon.client.contract.dictionaries.ability;
using Pokemons.client.pokemon.client.contract.dictionaries.generation;
using Pokemons.client.pokemon.client.contract.dictionaries.stats;
using Pokemons.client.pokemon.client.contract.dictionaries.type;

namespace Pokemons.client.pokemon.client.contract.dictionaries;

public class PokemonDictionariesClient : PokemonClientUrls, IPokemonDictionariesClient
{
    private WebClient _webClient;

    public PokemonDictionariesClient()
    {
        _webClient = new WebClient();
    }
    public List<TypeSummaryDto> GetTypes()
    {
        string url = GetUrl("type");
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<TypeListDto>(response).Types;
    }

    public List<GenerationSummaryDto> GetGenerations()
    {
        string url = GetUrl("generation");
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<GenerationListDto>(response).Generations;
    }

    public List<AbilitySummaryDto> GetAbilities()
    {
        string url = GetUrl("ability");
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<AbilityListDto>(response).Abilities;
    }

    public TypeDto GetType(string name)
    {
        string url = GetUrl("type", name);
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<TypeDto>(response);
    }

    public GenerationDto GetGeneration(string name)
    {
        string url = GetUrl("generation", name);
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<GenerationDto>(response);
    }

    public AbilityDto GetAbility(string name)
    {
        string url = GetUrl("ability", name);
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<AbilityDto>(response);
    }

    public List<StatsSummaryDto> GetStats()
    {
        string url = GetUrl("stat");
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<StatsListDto>(response).Stats;
    }
}