namespace Pokemons.updater.mapper;

public interface IMapper
{
    AbilityFromPokemonMapper GetAbilityFromPokemon();
    AbilityMapper GetAbility();
    GenerationMapper GetGeneration();
    PokemonMapper GetPokemon();
    ImageMapper GetImage();
    StatsFromPokemonMapper GetStatsFromPokemon();
    StatsMapper GetStats();
    TypeFromPokemonMapper GetTypeFromPokemon();
    TypeMapper GetType();
}