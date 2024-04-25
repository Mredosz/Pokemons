using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class StatsPokemon
{
    public Pokemon Pokemon { get; set; }

    public StatsFromPokemon StatsFromPokemon { get; set; }
}