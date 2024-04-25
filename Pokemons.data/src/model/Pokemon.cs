using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Pokemons.data.model;

public class Pokemon
{
    [Key]
    public int Id { get; set; }
    public int SourceId { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public string Name { get; set; }
    //One to one
    public Image? Image { get; set; }
    // One to many
    public Generation Generation { get; set; }
    public int GenerationId { get; set; }
    // Many to many

    public List<TypeFromPokemon>? Types { get; set; } = new();
    public List<StatsFromPokemon>? Stats { get; set; } = new();
    public List<AbilityFromPokemon>? Abilities { get; set; } = new();
}