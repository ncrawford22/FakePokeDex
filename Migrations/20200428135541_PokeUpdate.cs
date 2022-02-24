using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class PokeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Element_ElementTypeId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_ElementTypeId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "ElementTypeId",
                table: "Pokemons");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pokemons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pokemons");

            migrationBuilder.AddColumn<int>(
                name: "ElementTypeId",
                table: "Pokemons",
                type: "INTEGER",
                nullable: true);

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
    }
}
