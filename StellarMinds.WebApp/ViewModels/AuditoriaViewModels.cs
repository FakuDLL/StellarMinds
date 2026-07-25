using StellarMinds.WebApp.Services.Api;

namespace StellarMinds.WebApp.ViewModels;

public class AuditoriaListadoViewModel
{
    public int? CoordinadorId { get; set; }
    public string? Mensaje { get; set; }
    public List<ApiAuditoriaPrestamo> Auditorias { get; set; } = [];
}

public class AuditoriaDetalleViewModel
{
    public string? Mensaje { get; set; }
    public ApiAuditoriaPrestamo? Auditoria { get; set; }
}
