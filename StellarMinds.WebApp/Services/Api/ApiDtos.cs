namespace StellarMinds.WebApp.Services.Api;

public class ApiLoginRequest
{
    public string NombreUsuario { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class ApiLoginResponse
{
    public string Token { get; set; } = string.Empty;
    public ApiUsuarioLogueado Usuario { get; set; } = new();
}

public class ApiUsuarioLogueado
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NombreUsuario { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
}

public class ApiAltaUsuario
{
    public string NombreCompleto { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NombreUsuario { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Rol { get; set; }
}

public class ApiUsuarioResumen
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NombreUsuario { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;
}

public class ApiEquipo
{
    public int Id { get; set; }
    public string TipoEquipo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int CantidadDisponible { get; set; }
    public decimal? AperturaMm { get; set; }
    public decimal? RelacionFocal { get; set; }
    public decimal? DistanciaFocalMm { get; set; }
    public decimal? PesoKg { get; set; }
    public string? TipoMontura { get; set; }
    public decimal? CargaUtilKg { get; set; }
    public bool? EsComputarizado { get; set; }
    public string? TipoSensor { get; set; }
    public string? Resolucion { get; set; }
    public decimal? TamanoPixelMicras { get; set; }
    public decimal? DiametroMm { get; set; }
    public decimal? AnguloVisionGrados { get; set; }
}

public class ApiDisponibilidadEquipo
{
    public int EquipoId { get; set; }
    public string TipoEquipo { get; set; } = string.Empty;
    public bool Disponible { get; set; }
    public int CantidadDisponible { get; set; }
    public string Mensaje { get; set; } = string.Empty;
}

public class ApiAltaPrestamo
{
    public int SocioId { get; set; }
    public int TelescopioId { get; set; }
    public int MonturaId { get; set; }
    public int? CamaraId { get; set; }
    public int? OcularId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}

public class ApiPrestamo
{
    public int Id { get; set; }
    public int SocioId { get; set; }
    public string SocioNombre { get; set; } = string.Empty;
    public int TelescopioId { get; set; }
    public int MonturaId { get; set; }
    public int? CamaraId { get; set; }
    public int? OcularId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string Estado { get; set; } = string.Empty;
}

public class ApiPrestamoConAtraso : ApiPrestamo
{
    public bool EstaAtrasado { get; set; }
}

public class ApiAuditoriaPrestamo
{
    public int Id { get; set; }
    public int PrestamoId { get; set; }
    public string Accion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public int CoordinadorId { get; set; }
    public string CoordinadorNombre { get; set; } = string.Empty;
    public int SocioId { get; set; }
    public string SocioNombre { get; set; } = string.Empty;
    public DateTime PrestamoFechaInicio { get; set; }
    public DateTime PrestamoFechaFin { get; set; }
    public string PrestamoEstado { get; set; } = string.Empty;
    public string AuditoriaDetalleUrl { get; set; } = string.Empty;
    public string PrestamoDetalleUrl { get; set; } = string.Empty;
}

public class ApiObjetoCeleste
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal MagnitudAparente { get; set; }
}

public class ApiEvaluarObservacion
{
    public int PrestamoId { get; set; }
    public int ObjetoCelesteId { get; set; }
    public DateTime Fecha { get; set; }
}

public class ApiEvaluacionObservacion
{
    public string Indicador { get; set; } = string.Empty;
    public string Detalle { get; set; } = string.Empty;
}

public class ApiAltaObservacion
{
    public int PrestamoId { get; set; }
    public int ObjetoCelesteId { get; set; }
    public DateTime Fecha { get; set; }
    public string Indicador { get; set; } = string.Empty;
    public string Detalle { get; set; } = string.Empty;
}

public class ApiIdResponse
{
    public int Id { get; set; }
    public int IdPrestamo { get; set; }
}

public class ApiRankingObjetoCeleste
{
    public int ObjetoCelesteId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public int CantidadVecesObservado { get; set; }
}
