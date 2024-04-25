using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Pokemons.data;
using Pokemons.web.service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<DbPokemonContext>();
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
    pattern: "{controller=Web}/{action=index}");

app.Run();