using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class StatsFromPokemon
{
    [Key]
    public int Id { get; set; }
    public int BaseStat { get; set; }
    public int Effort { get; set; }
    public Stats Stats { get; set; }
    public int StatsId { get; set; }
    public List<Pokemon> Pokemons { get; set; } = new();
}