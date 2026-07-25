using System.ComponentModel.DataAnnotations;
using StellarMinds.WebApp.Services.Api;

namespace StellarMinds.WebApp.ViewModels;

public class AltaPrestamoViewModel
{
    [Required]
    public int SocioId { get; set; }

    [Required]
    public int TelescopioId { get; set; }

    [Required]
    public int MonturaId { get; set; }

    public int? CamaraId { get; set; }
    public int? OcularId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaInicio { get; set; } = DateTime.Today;

    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaFin { get; set; } = DateTime.Today.AddDays(7);

    public List<ApiUsuarioResumen> Socios { get; set; } = [];
    public List<ApiEquipo> Telescopios { get; set; } = [];
    public List<ApiEquipo> Monturas { get; set; } = [];
    public List<ApiEquipo> Camaras { get; set; } = [];
    public List<ApiEquipo> Oculares { get; set; } = [];
}

public class DevolucionPrestamoViewModel
{
    public int SocioId { get; set; }
    public List<ApiUsuarioResumen> Socios { get; set; } = [];
    public List<ApiPrestamo> Prestamos { get; set; } = [];
}

public class MisPrestamosViewModel
{
    [Range(1, 12)]
    public int Mes { get; set; } = DateTime.Today.Month;

    [Range(2000, 2100)]
    public int Anio { get; set; } = DateTime.Today.Year;

    public bool BusquedaRealizada { get; set; }
    public string? Mensaje { get; set; }
    public List<ApiPrestamoConAtraso> Prestamos { get; set; } = [];
}
