using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StellarMinds.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RF04_RF05_RF06_PrestamosAuditoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    SocioId = table.Column<int>(type: "int", nullable: false),
                    TelescopioId = table.Column<int>(type: "int", nullable: false),
                    MonturaId = table.Column<int>(type: "int", nullable: false),
                    CamaraId = table.Column<int>(type: "int", nullable: true),
                    OcularId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_CamaraId",
                        column: x => x.CamaraId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_MonturaId",
                        column: x => x.MonturaId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_OcularId",
                        column: x => x.OcularId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Equipos_TelescopioId",
                        column: x => x.TelescopioId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriasPrestamo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accion = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    CoordinadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriasPrestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriasPrestamo_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditoriasPrestamo_Usuarios_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriasPrestamo_CoordinadorId",
                table: "AuditoriasPrestamo",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriasPrestamo_PrestamoId",
                table: "AuditoriasPrestamo",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_CamaraId",
                table: "Prestamos",
                column: "CamaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_MonturaId",
                table: "Prestamos",
                column: "MonturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_OcularId",
                table: "Prestamos",
                column: "OcularId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_SocioId",
                table: "Prestamos",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_TelescopioId",
                table: "Prestamos",
                column: "TelescopioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditoriasPrestamo");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
