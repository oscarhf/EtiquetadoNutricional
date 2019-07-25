using Microsoft.EntityFrameworkCore.Migrations;

namespace Etiquetas.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Densidad",
                table: "Proximales",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PorcionCantidadG",
                table: "Proximales",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Densidad",
                table: "Proximales");

            migrationBuilder.DropColumn(
                name: "PorcionCantidadG",
                table: "Proximales");
        }
    }
}
