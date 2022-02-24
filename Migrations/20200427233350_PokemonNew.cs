using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class PokemonNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "ElementTypeId",
                table: "Pokemons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_ElementTypeId",
                table: "Pokemons",
                column: "ElementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Element_ElementTypeId",
                table: "Pokemons",
                column: "ElementTypeId",
                principalTable: "Element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Element_ElementTypeId",
                table: "Pokemons");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_ElementTypeId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "ElementTypeId",
                table: "Pokemons");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pokemons",
                type: "TEXT",
                nullable: true);
        }
    }
}
