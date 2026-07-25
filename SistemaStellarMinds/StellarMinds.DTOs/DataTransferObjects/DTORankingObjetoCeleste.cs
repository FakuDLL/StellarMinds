namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTORankingObjetoCeleste
    {
        public int ObjetoCelesteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int CantidadVecesObservado { get; set; }
    }
}
