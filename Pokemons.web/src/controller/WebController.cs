using Azure;
using Microsoft.AspNetCore.Mvc;
using Pokemons.data.model;
using Pokemons.web.contract;
using Pokemons.web.service;

namespace Pokemons.web.controller;
[Controller]
public class WebController : Controller
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