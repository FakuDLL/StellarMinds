namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTOEquipo
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
}
