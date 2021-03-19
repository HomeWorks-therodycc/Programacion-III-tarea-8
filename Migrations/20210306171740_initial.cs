using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea7.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vacunas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    marca = table.Column<string>(type: "TEXT", nullable: false),
                    cantidad_restante = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidad_entrante = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacunas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vacunados",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cedula = table.Column<string>(type: "TEXT", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    telefono = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    signo_zodiacal = table.Column<string>(type: "TEXT", nullable: false),
                    provincia_id = table.Column<int>(type: "INTEGER", nullable: false),
                    vacuna1_id = table.Column<int>(type: "INTEGER", nullable: true),
                    vacuna1_fecha = table.Column<DateTime>(type: "TEXT", nullable: true),
                    vacuna2_id = table.Column<int>(type: "INTEGER", nullable: true),
                    vacuna2_fecha = table.Column<DateTime>(type: "TEXT", nullable: true),
                    latitud = table.Column<double>(type: "REAL", nullable: true),
                    longitud = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacunados", x => x.id);
                    table.ForeignKey(
                        name: "FK_vacunados_provincias_provincia_id",
                        column: x => x.provincia_id,
                        principalTable: "provincias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vacunados_vacunas_vacuna1_id",
                        column: x => x.vacuna1_id,
                        principalTable: "vacunas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vacunados_vacunas_vacuna2_id",
                        column: x => x.vacuna2_id,
                        principalTable: "vacunas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vacunados_cedula",
                table: "vacunados",
                column: "cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacunados_provincia_id",
                table: "vacunados",
                column: "provincia_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacunados_vacuna1_id",
                table: "vacunados",
                column: "vacuna1_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacunados_vacuna2_id",
                table: "vacunados",
                column: "vacuna2_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacunados");

            migrationBuilder.DropTable(
                name: "provincias");

            migrationBuilder.DropTable(
                name: "vacunas");
        }
    }
}
