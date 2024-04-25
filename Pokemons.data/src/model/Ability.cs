namespace Pokemons.data.model;

public class Ability
{
    public int Id { get; set; }
    public int SourceId { get; set; }
    public string Name { get; set; }
    public Generation Generation { get; set; }
    public int GenerationId { get; set; }
    public List<AbilityFromPokemon> AbilityFromPokemons { get; set; } = new();
}