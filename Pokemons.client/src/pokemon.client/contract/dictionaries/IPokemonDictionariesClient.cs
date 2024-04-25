using Pokemons.client.pokemon.client.contract.dictionaries.ability;
using Pokemons.client.pokemon.client.contract.dictionaries.generation;
using Pokemons.client.pokemon.client.contract.dictionaries.stats;
using Pokemons.client.pokemon.client.contract.dictionaries.type;

namespace Pokemons.client.pokemon.client.contract.dictionaries;

public interface IPokemonDictionariesClient
{
    List<TypeSummaryDto> GetTypes();
    List<GenerationSummaryDto> GetGenerations();
    List<AbilitySummaryDto> GetAbilities();
    TypeDto GetType(string name);
    GenerationDto GetGeneration(string name);
    AbilityDto GetAbility(string name);
    List<StatsSummaryDto> GetStats();
}