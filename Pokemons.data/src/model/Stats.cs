using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class Stats
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<StatsFromPokemon> StatsFromPokemons { get; set; } = new();
}