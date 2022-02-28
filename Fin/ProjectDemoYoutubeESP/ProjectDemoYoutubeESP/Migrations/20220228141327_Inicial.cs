using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDemoYoutubeESP.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EstaLogueado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direccion_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Cedula", "EstaLogueado", "FechaNacimiento", "Nombre", "Salario" },
                values: new object[] { 1, "123", true, new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felipe", 123.45m });

            migrationBuilder.InsertData(
                table: "Direccion",
                columns: new[] { "Id", "Calle", "CodigoPostal", "Comentario", "Pais", "PersonaId", "Provincia", "Telefono" },
                values: new object[] { 1, "Calle 123", "Codigo postal 123", "Hay perro", "Rep. Dominicana", 1, "Provincia 123", "123-456" });

            migrationBuilder.InsertData(
                table: "Direccion",
                columns: new[] { "Id", "Calle", "CodigoPostal", "Comentario", "Pais", "PersonaId", "Provincia", "Telefono" },
                values: new object[] { 2, "Calle 456", "Codigo postal 456", "Hay dos perros", "Rep. Dominicana", 1, "Provincia 456", "456-789" });

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_PersonaId",
                table: "Direccion",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
