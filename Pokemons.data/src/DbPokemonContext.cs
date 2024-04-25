using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Pokemons.data.model;
using Type = Pokemons.data.model.Type;

namespace Pokemons.data;

public class DbPokemonContext : DbContext
{
    public DbPokemonContext(DbContextOptions<DbPokemonContext> options) : base(options) {}

    public DbSet<Ability> Abilities { get; set; }
    public DbSet<AbilityFromPokemon> AbilityFromPokemon { get; set; }
    public DbSet<Generation> Generations { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<Stats> Stats { get; set; }
    public DbSet<StatsFromPokemon> StatsFromPokemon { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<TypeFromPokemon> TypeFromPokemon { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("pokemons");
        builder.Entity<Pokemon>()
            .HasOne(i => i.Image)
            .WithOne(p => p.Pokemon)
            .HasForeignKey<Image>(p => p.PokemonId);

        builder.Entity<Stats>()
            .HasMany(i => i.StatsFromPokemons)
            .WithOne(p => p.Stats)
            .HasForeignKey(p => p.StatsId);

        builder.Entity<Ability>()
            .HasOne(i => i.Generation)
            .WithMany(p => p.Abilities)
            .HasForeignKey(p => p.GenerationId);

        builder.Entity<Pokemon>()
            .HasOne(i => i.Generation)
            .WithMany(p => p.Pokemons)
            .HasForeignKey(p => p.GenerationId);

        builder.Entity<TypeFromPokemon>()
            .HasOne(i => i.Type)
            .WithMany(p => p.TypeFromPokemons)
            .HasForeignKey(p => p.TypeId);

        builder.Entity<AbilityFromPokemon>()
            .HasOne(i => i.Ability)
            .WithMany(p => p.AbilityFromPokemons)
            .HasForeignKey(p => p.AbilityId);
    }
}