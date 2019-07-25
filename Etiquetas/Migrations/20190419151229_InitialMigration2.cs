using Microsoft.EntityFrameworkCore.Migrations;

namespace Etiquetas.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Densidad",
                table: "Porciones",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Cantidad",
                table: "Porciones",
                nullable: true,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Densidad",
                table: "Porciones",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Cantidad",
                table: "Porciones",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
