namespace Pokemons.updater.mapper;

public interface IMap<TDto, TEntity>
{
    TEntity ToEntity(TDto dto);
}