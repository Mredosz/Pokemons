using System.ComponentModel.DataAnnotations;

namespace Pokemons.data.model;

public class AbilityFromPokemon
{
    [Key]
    public int Id { get; set; }
    public int Slot { get; set; }
    public Ability Ability { get; set; }
    public int AbilityId { get; set; }
    public List<Pokemon> Pokemons { get; set; } = new();
}