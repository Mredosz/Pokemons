using Microsoft.AspNetCore.Mvc;
using Pokemons.web.contract;
using Pokemons.web.service;

namespace Pokemons.web.controller;
[ApiController]
public class WebController : ControllerBase
{
    private IPokemonService _service;

    public WebController(IPokemonService service)
    {
        _service = service;
    }

    [HttpGet ("pokemons")]
    public List<PokemonSummaryDto> Index()
    {
        return _service.GetAllPokemons();
    }

    [HttpGet ("pokemons/{id}")]
    public PokemonDto Details(int id)
    {
        return _service.GetPokemonById(id);
    }
}