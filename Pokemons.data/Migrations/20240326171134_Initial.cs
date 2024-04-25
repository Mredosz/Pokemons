using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokemons.data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pokemons");

            migrationBuilder.CreateTable(
                name: "Generations",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalSchema: "pokemons",
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalSchema: "pokemons",
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatsFromPokemon",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseStat = table.Column<int>(type: "int", nullable: false),
                    Effort = table.Column<int>(type: "int", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsFromPokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatsFromPokemon_Stats_StatsId",
                        column: x => x.StatsId,
                        principalSchema: "pokemons",
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeFromPokemon",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFromPokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeFromPokemon_Types_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "pokemons",
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityFromPokemon",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityFromPokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityFromPokemon_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalSchema: "pokemons",
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalSchema: "pokemons",
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonStatsFromPokemon",
                schema: "pokemons",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "int", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonStatsFromPokemon", x => new { x.PokemonsId, x.StatsId });
                    table.ForeignKey(
                        name: "FK_PokemonStatsFromPokemon_Pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalSchema: "pokemons",
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonStatsFromPokemon_StatsFromPokemon_StatsId",
                        column: x => x.StatsId,
                        principalSchema: "pokemons",
                        principalTable: "StatsFromPokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypeFromPokemon",
                schema: "pokemons",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "int", nullable: false),
                    TypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypeFromPokemon", x => new { x.PokemonsId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_PokemonTypeFromPokemon_Pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalSchema: "pokemons",
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTypeFromPokemon_TypeFromPokemon_TypesId",
                        column: x => x.TypesId,
                        principalSchema: "pokemons",
                        principalTable: "TypeFromPokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityFromPokemonPokemon",
                schema: "pokemons",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "int", nullable: false),
                    AbilitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityFromPokemonPokemon", x => new { x.PokemonsId, x.AbilitiesId });
                    table.ForeignKey(
                        name: "FK_AbilityFromPokemonPokemon_Pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalSchema: "pokemons",
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityFromPokemonPokemon_AbilityFromPokemon_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalSchema: "pokemons",
                        principalTable: "AbilityFromPokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_GenerationId",
                schema: "pokemons",
                table: "Abilities",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityFromPokemon_AbilityId",
                schema: "pokemons",
                table: "AbilityFromPokemon",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityFromPokemonPokemon_PokemonsId",
                schema: "pokemons",
                table: "AbilityFromPokemonPokemon",
                column: "PokemonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PokemonId",
                schema: "pokemons",
                table: "Images",
                column: "PokemonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_GenerationId",
                schema: "pokemons",
                table: "Pokemon",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonStatsFromPokemon_StatsId",
                schema: "pokemons",
                table: "PokemonStatsFromPokemon",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypeFromPokemon_TypesId",
                schema: "pokemons",
                table: "PokemonTypeFromPokemon",
                column: "TypesId");

            migrationBuilder.CreateIndex(
                name: "IX_StatsFromPokemon_StatsId",
                schema: "pokemons",
                table: "StatsFromPokemon",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeFromPokemon_TypeId",
                schema: "pokemons",
                table: "TypeFromPokemon",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityFromPokemonPokemon",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "PokemonStatsFromPokemon",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "PokemonTypeFromPokemon",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "AbilityFromPokemon",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "StatsFromPokemon",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "Pokemon",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "TypeFromPokemon",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "Abilities",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "Stats",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "pokemons");

            migrationBuilder.DropTable(
                name: "Generations",
                schema: "pokemons");
        }
    }
}
