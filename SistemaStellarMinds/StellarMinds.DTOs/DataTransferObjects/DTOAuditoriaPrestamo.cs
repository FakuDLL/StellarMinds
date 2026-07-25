namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTOAuditoriaPrestamo
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
}
