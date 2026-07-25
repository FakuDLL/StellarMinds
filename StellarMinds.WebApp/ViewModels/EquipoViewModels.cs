using System.ComponentModel.DataAnnotations;
using StellarMinds.WebApp.Services.Api;

namespace StellarMinds.WebApp.ViewModels;

public class EquipoListadoViewModel
{
    public string? Tipo { get; set; }
    public List<ApiEquipo> Equipos { get; set; } = [];
}

public class EquipoFormViewModel
{
    public int Id { get; set; }

    [Required]
    public string TipoEquipo { get; set; } = "telescopio";

    [Required]
    public string Marca { get; set; } = string.Empty;

    [Required]
    public string Modelo { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
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

    public ApiEquipo ToDto() => new()
    {
        Id = Id,
        TipoEquipo = TipoEquipo,
        Marca = Marca,
        Modelo = Modelo,
        CantidadDisponible = CantidadDisponible,
        AperturaMm = AperturaMm,
        RelacionFocal = RelacionFocal,
        DistanciaFocalMm = DistanciaFocalMm,
        PesoKg = PesoKg,
        TipoMontura = TipoMontura,
        CargaUtilKg = CargaUtilKg,
        EsComputarizado = EsComputarizado,
        TipoSensor = TipoSensor,
        Resolucion = Resolucion,
        TamanoPixelMicras = TamanoPixelMicras,
        DiametroMm = DiametroMm,
        AnguloVisionGrados = AnguloVisionGrados
    };

    public static EquipoFormViewModel FromDto(ApiEquipo dto) => new()
    {
        Id = dto.Id,
        TipoEquipo = dto.TipoEquipo,
        Marca = dto.Marca,
        Modelo = dto.Modelo,
        CantidadDisponible = dto.CantidadDisponible,
        AperturaMm = dto.AperturaMm,
        RelacionFocal = dto.RelacionFocal,
        DistanciaFocalMm = dto.DistanciaFocalMm,
        PesoKg = dto.PesoKg,
        TipoMontura = dto.TipoMontura,
        CargaUtilKg = dto.CargaUtilKg,
        EsComputarizado = dto.EsComputarizado,
        TipoSensor = dto.TipoSensor,
        Resolucion = dto.Resolucion,
        TamanoPixelMicras = dto.TamanoPixelMicras,
        DiametroMm = dto.DiametroMm,
        AnguloVisionGrados = dto.AnguloVisionGrados
    };
}

public class SociosPorTelescopioViewModel
{
    public int TelescopioId { get; set; }
    public string? Mensaje { get; set; }
    public List<ApiEquipo> Telescopios { get; set; } = [];
    public List<ApiUsuarioResumen> Socios { get; set; } = [];
}
