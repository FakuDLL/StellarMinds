namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTOObservacion
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public string ObjetoCelesteNombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Indicador { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
    }
}
