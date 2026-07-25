using System.ComponentModel.DataAnnotations;
using StellarMinds.WebApp.Services.Api;

namespace StellarMinds.WebApp.ViewModels;

public class AltaObservacionViewModel
{
    [Required]
    public int PrestamoId { get; set; }

    [Required]
    public int ObjetoCelesteId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Today;

    public string Indicador { get; set; } = string.Empty;
    public string Detalle { get; set; } = string.Empty;
    public bool EvaluacionVigente { get; set; }

    public List<ApiPrestamo> Prestamos { get; set; } = [];
    public List<ApiObjetoCeleste> ObjetosCelestes { get; set; } = [];
}
