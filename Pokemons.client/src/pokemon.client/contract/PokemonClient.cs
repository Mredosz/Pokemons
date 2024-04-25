using System.Net;
using Newtonsoft.Json;
using Pokemons.client.pokemon.client.contract.dictionaries.stats;
using Pokemons.client.pokemon.client.contract.pokemon;

namespace Pokemons.client.pokemon.client.contract;

public class PokemonClient : PokemonClientUrls, IPokemonClient
{
    private WebClient _webClient;

    public PokemonClient()
    {
        _webClient = new WebClient();
    }
    public List<PokemonSummaryDto> GetPokemons(int quantity, int nextId)
    {
        string url = GetUrl("pokemon", quantity, nextId);
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<PokemonListDto>(response).Pokemons;
    }

    public PokemonDto GetPokemon(string name)
    {
        string url = GetUrl("pokemon", name);
        var response = _webClient.DownloadString(url);
        return JsonConvert.DeserializeObject<PokemonDto>(response);
    }
}