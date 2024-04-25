using System.Net.Http.Headers;

namespace Pokemons.client.pokemon.client.contract;

public abstract class PokemonClientUrls
{
    private const string SCHEME_NAME = "https";
    private const string HOST_NAME = "pokeapi.co/api/v2";
    public string GetUrl(string pathSegment)
    {
        var uri = new UriBuilder(SCHEME_NAME, HOST_NAME)
        {
            Path = $"{pathSegment}",
            Query = $"limit=400"
        };
        return uri.Uri.ToString();
    }

    public string GetUrl(string pathSegment, int quantity, int nextId)
    {
        var uri = new UriBuilder(SCHEME_NAME, HOST_NAME)
        {
            Path = $"{pathSegment}",
            Query = $"limit={quantity}&offset={nextId}"
        };
        return uri.Uri.ToString();
    }

    public string GetUrl(string pathSegment, string name)
    {
        var uri = new UriBuilder(SCHEME_NAME, HOST_NAME)
        {
            Path = $"{pathSegment}/{name}"
        };
        return uri.Uri.ToString();
    }
}