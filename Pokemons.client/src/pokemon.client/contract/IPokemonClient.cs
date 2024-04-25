using Pokemons.client.pokemon.client.contract.dictionaries.stats;
using Pokemons.client.pokemon.client.contract.pokemon;

namespace Pokemons.client.pokemon.client.contract;

public interface IPokemonClient
{
    List<PokemonSummaryDto> GetPokemons(int quantity, int nextId);
    PokemonDto GetPokemon(string name);
}