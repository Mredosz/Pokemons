using Pokemons.web.contract;

namespace Pokemons.web.service;

public interface IPokemonService
{
    List<PokemonSummaryDto> GetAllPokemons();
    PokemonDto GetPokemonById(int id);
}