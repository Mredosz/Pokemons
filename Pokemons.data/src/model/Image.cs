using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class Image
{
    [Key]
    public int Id { get; set; }
    public string Url { get; set; }
    public Pokemon Pokemon { get; set; }
    public int PokemonId { get; set; }
}