namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTOAltaObservacion
    {
        public int PrestamoId { get; set; }
        public int ObjetoCelesteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Indicador { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
    }
}
