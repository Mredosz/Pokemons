using Pokemons.client.pokemon.client.contract.pokemon;
using Pokemons.data.model;

namespace Pokemons.updater.mapper;

public class ImageMapper : IMap<PokemonDto.ImageSummaryDto, Image>
{
    public Image ToEntity(PokemonDto.ImageSummaryDto dto)
    {
        return new Image()
        {
            Url = dto.Url
        };
    }
}