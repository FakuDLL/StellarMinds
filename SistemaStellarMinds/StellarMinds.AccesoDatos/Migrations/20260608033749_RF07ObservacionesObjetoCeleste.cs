using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StellarMinds.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RF07ObservacionesObjetoCeleste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjetosCelestes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    MagnitudAparente = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosCelestes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Observaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    ObjetoCelesteId = table.Column<int>(type: "int", nullable: false),
                    IndicadorIA = table.Column<int>(type: "int", nullable: false),
                    DetalleEvaluacion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observaciones_ObjetosCelestes_ObjetoCelesteId",
                        column: x => x.ObjetoCelesteId,
                        principalTable: "ObjetosCelestes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observaciones_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ObjetosCelestes",
                columns: new[] { "Id", "MagnitudAparente", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { 1, -12.74m, "Luna", 5 },
                    { 2, -2.20m, "Júpiter", 1 },
                    { 3, 0.46m, "Saturno", 1 },
                    { 4, 4.00m, "Galaxia M42", 3 },
                    { 5, 1.98m, "Polaris", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjetosCelestes_Nombre",
                table: "ObjetosCelestes",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_ObjetoCelesteId",
                table: "Observaciones",
                column: "ObjetoCelesteId");

            migrationBuilder.CreateIndex(
                name: "IX_Observaciones_PrestamoId",
                table: "Observaciones",
                column: "PrestamoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observaciones");

            migrationBuilder.DropTable(
                name: "ObjetosCelestes");
        }
    }
}
