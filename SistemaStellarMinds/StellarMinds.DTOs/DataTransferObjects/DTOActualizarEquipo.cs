namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTOActualizarEquipo
    {
        public int Id { get; set; }
        public string TipoEquipo { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int CantidadDisponible { get; set; }

        // Telescopio
        public decimal? AperturaMm { get; set; }
        public decimal? RelacionFocal { get; set; }
        public decimal? DistanciaFocalMm { get; set; }
        public decimal? PesoKg { get; set; }

        // Montura
        public string? TipoMontura { get; set; }
        public decimal? CargaUtilKg { get; set; }
        public bool? EsComputarizado { get; set; }

        // Camara
        public string? TipoSensor { get; set; }
        public string? Resolucion { get; set; }
        public decimal? TamanoPixelMicras { get; set; }

        // Ocular
        public decimal? DiametroMm { get; set; }
        public decimal? AnguloVisionGrados { get; set; }
    }
}
