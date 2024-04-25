using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class TypeFromPokemon
{
    [Key]
    public int Id { get; set; }
    public int Slot { get; set; }
    public Type Type { get; set; }
    public int TypeId { get; set; }
    public List<Pokemon> Pokemons { get; set; } = new();
}