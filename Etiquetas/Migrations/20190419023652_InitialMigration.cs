using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Etiquetas.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    codFAO = table.Column<string>(nullable: true),
                    Grupo = table.Column<string>(nullable: true),
                    Provedor = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    Certificate = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Calorias = table.Column<float>(nullable: true),
                    Azucar = table.Column<float>(nullable: true),
                    Agua = table.Column<float>(nullable: true),
                    Proteinas = table.Column<float>(nullable: true),
                    Grasa = table.Column<float>(nullable: true),
                    GrasaSaturada = table.Column<float>(nullable: true),
                    Carbohidratos = table.Column<float>(nullable: true),
                    FibraDietetica = table.Column<float>(nullable: true),
                    Cenizas = table.Column<float>(nullable: true),
                    GrasaTrans = table.Column<float>(nullable: true),
                    Colesterol = table.Column<float>(nullable: true),
                    Va = table.Column<float>(nullable: true),
                    Vb1 = table.Column<float>(nullable: true),
                    Vb2 = table.Column<float>(nullable: true),
                    Vb3 = table.Column<float>(nullable: true),
                    Vb5 = table.Column<float>(nullable: true),
                    Vb7 = table.Column<float>(nullable: true),
                    Vb9 = table.Column<float>(nullable: true),
                    Vb12 = table.Column<float>(nullable: true),
                    Vc = table.Column<float>(nullable: true),
                    Vd = table.Column<float>(nullable: true),
                    Ve = table.Column<float>(nullable: true),
                    Vk = table.Column<float>(nullable: true),
                    Calcio = table.Column<float>(nullable: true),
                    Fosforo = table.Column<float>(nullable: true),
                    Fluor = table.Column<float>(nullable: true),
                    Hierro = table.Column<float>(nullable: true),
                    Sodio = table.Column<float>(nullable: true),
                    Yodo = table.Column<float>(nullable: true),
                    Zinc = table.Column<float>(nullable: true),
                    Potasio = table.Column<float>(nullable: true),
                    Cloruro = table.Column<float>(nullable: true),
                    Magnesio = table.Column<float>(nullable: true),
                    Cobre = table.Column<float>(nullable: true),
                    Selenio = table.Column<float>(nullable: true),
                    Cromo = table.Column<float>(nullable: true),
                    Molibdeno = table.Column<float>(nullable: true),
                    Manganeso = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Cantidad = table.Column<float>(nullable: false),
                    Unidad = table.Column<string>(nullable: true),
                    Densidad = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    Annotation = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    isLey = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proximales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PorcionCantidad = table.Column<float>(nullable: false),
                    PorcionUnidad = table.Column<string>(nullable: true),
                    PorcionId = table.Column<int>(nullable: false),
                    Calorias = table.Column<float>(nullable: true),
                    Azucar = table.Column<float>(nullable: true),
                    Agua = table.Column<float>(nullable: true),
                    Proteinas = table.Column<float>(nullable: true),
                    Grasa = table.Column<float>(nullable: true),
                    GrasaSaturada = table.Column<float>(nullable: true),
                    Carbohidratos = table.Column<float>(nullable: true),
                    FibraDietetica = table.Column<float>(nullable: true),
                    Cenizas = table.Column<float>(nullable: true),
                    GrasaTrans = table.Column<float>(nullable: true),
                    Colesterol = table.Column<float>(nullable: true),
                    Va = table.Column<float>(nullable: true),
                    Vb1 = table.Column<float>(nullable: true),
                    Vb2 = table.Column<float>(nullable: true),
                    Vb3 = table.Column<float>(nullable: true),
                    Vb5 = table.Column<float>(nullable: true),
                    Vb7 = table.Column<float>(nullable: true),
                    Vb9 = table.Column<float>(nullable: true),
                    Vb12 = table.Column<float>(nullable: true),
                    Vc = table.Column<float>(nullable: true),
                    Vd = table.Column<float>(nullable: true),
                    Ve = table.Column<float>(nullable: true),
                    Vk = table.Column<float>(nullable: true),
                    Calcio = table.Column<float>(nullable: true),
                    Fosforo = table.Column<float>(nullable: true),
                    Fluor = table.Column<float>(nullable: true),
                    Hierro = table.Column<float>(nullable: true),
                    Sodio = table.Column<float>(nullable: true),
                    Yodo = table.Column<float>(nullable: true),
                    Zinc = table.Column<float>(nullable: true),
                    Potasio = table.Column<float>(nullable: true),
                    Cloruro = table.Column<float>(nullable: true),
                    Magnesio = table.Column<float>(nullable: true),
                    Cobre = table.Column<float>(nullable: true),
                    Selenio = table.Column<float>(nullable: true),
                    Cromo = table.Column<float>(nullable: true),
                    Molibdeno = table.Column<float>(nullable: true),
                    Manganeso = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proximales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proximales_Porciones_PorcionId",
                        column: x => x.PorcionId,
                        principalTable: "Porciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formulaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<string>(nullable: true),
                    ProximalId = table.Column<int>(nullable: true),
                    IngredienteId = table.Column<int>(nullable: true),
                    Percentage = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formulaciones_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Formulaciones_Proximales_ProximalId",
                        column: x => x.ProximalId,
                        principalTable: "Proximales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Formulaciones_IngredienteId",
                table: "Formulaciones",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulaciones_ProximalId",
                table: "Formulaciones",
                column: "ProximalId");

            migrationBuilder.CreateIndex(
                name: "IX_Proximales_PorcionId",
                table: "Proximales",
                column: "PorcionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Formulaciones");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Proximales");

            migrationBuilder.DropTable(
                name: "Porciones");
        }
    }
}
