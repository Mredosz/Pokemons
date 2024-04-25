using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class Generation
{
    [Key]
    public int Id { get; set; }
    public int SourceId { get; set; }
    public string Name { get; set; }
    public List<Ability> Abilities { get; set; } = new();
    public List<Pokemon> Pokemons { get; set; } = new();
}