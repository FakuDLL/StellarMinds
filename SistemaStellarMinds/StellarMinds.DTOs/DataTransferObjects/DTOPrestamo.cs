namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTOPrestamo
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
}
