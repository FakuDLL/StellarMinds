using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StellarMinds.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RF03Equipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    TipoEquipo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    TipoSensor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Resolucion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TamanoPixelMicras = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TipoMontura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CargaUtilKg = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EsComputarizado = table.Column<bool>(type: "bit", nullable: true),
                    DiametroMm = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AnguloVisionGrados = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AperturaMm = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    RelacionFocal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DistanciaFocalMm = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PesoKg = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}
