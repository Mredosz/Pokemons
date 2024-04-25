namespace Pokemons.updater.mapper;

public class Mapper
{
    public Mapper(AbilityFromPokemonMapper abilityFromPokemon, AbilityMapper ability, GenerationMapper generation, PokemonMapper pokemon, ImageMapper image, StatsFromPokemonMapper statsFromPokemon, StatsMapper stats, TypeFromPokemonMapper typeFromPokemon, TypeMapper type)
    {
        AbilityFromPokemon = abilityFromPokemon;
        Ability = ability;
        Generation = generation;
        Pokemon = pokemon;
        Image = image;
        StatsFromPokemon = statsFromPokemon;
        Stats = stats;
        TypeFromPokemon = typeFromPokemon;
        Type = type;
    }

    public AbilityFromPokemonMapper AbilityFromPokemon { get; }
    public AbilityMapper Ability { get; }
    public GenerationMapper Generation { get; }
    public PokemonMapper Pokemon { get; }
    public ImageMapper Image { get; }
    public StatsFromPokemonMapper StatsFromPokemon { get; }
    public StatsMapper Stats { get; }
    public TypeFromPokemonMapper TypeFromPokemon { get; }
    public TypeMapper Type { get; }

}