using Microsoft.AspNetCore.Mvc;
using Pokemons.updater.service;

namespace Pokemons.updater.controler;
[Controller]
public class UpdaterController : Controller
{
    private IPokemonUpdaterService _pokemonUpdaterService;

    public UpdaterController(IPokemonUpdaterService pokemonUpdaterService)
    {
        _pokemonUpdaterService = pokemonUpdaterService;
    }

    [HttpGet ("/update/{quantity}")]
    public void Update([FromRoute]int quantity)
    {
        _pokemonUpdaterService.Update(quantity);
    }
}