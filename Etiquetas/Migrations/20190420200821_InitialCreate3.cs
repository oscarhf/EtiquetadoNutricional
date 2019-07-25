using Microsoft.EntityFrameworkCore.Migrations;

namespace Etiquetas.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PorcionRemplazo",
                table: "Proximales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcionRemplazo",
                table: "Proximales");
        }
    }
}
