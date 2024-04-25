using Microsoft.EntityFrameworkCore;
using Pokemons.client.pokemon.client.contract;
using Pokemons.client.pokemon.client.contract.dictionaries;
using Pokemons.data;
using Pokemons.updater.mapper;
using Pokemons.updater.service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPokemonUpdaterService, PokemonUpdaterService>();
builder.Services.AddScoped<IPokemonDictionariesClient, PokemonDictionariesClient>();
builder.Services.AddScoped<IPokemonClient, PokemonClient>();
builder.Services.AddScoped<Mapper>();
builder.Services.AddScoped<AbilityFromPokemonMapper>();
builder.Services.AddScoped<AbilityMapper>();
builder.Services.AddScoped<GenerationMapper>();
builder.Services.AddScoped<ImageMapper>();
builder.Services.AddScoped<PokemonMapper>();
builder.Services.AddScoped<StatsFromPokemonMapper>();
builder.Services.AddScoped<StatsMapper>();
builder.Services.AddScoped<TypeFromPokemonMapper>();
builder.Services.AddScoped<TypeMapper>();
builder.Services.AddDbContext<DbPokemonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Updater}/{action=Update}/{quantity?}");

app.Run();