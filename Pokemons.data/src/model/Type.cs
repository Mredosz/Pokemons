using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class Type
{
    [Key]
    public int Id { get; set; }
    public int SourceId { get; set; }
    public string Name { get; set; }
    public List<TypeFromPokemon> TypeFromPokemons { get; set; } = new();
}