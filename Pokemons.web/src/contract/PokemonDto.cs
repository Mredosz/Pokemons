
namespace Pokemons.web.contract;

public class PokemonDto : PokemonSummaryDto
{
    public int Weight { get; set; }
    public int Height { get; set; }
    public string Generation { get; set; }
    public List<string>? Abilities { get; set; }
    public List<string>? Types { get; set; }
    public List<Stats>? Stats { get; set; }
}