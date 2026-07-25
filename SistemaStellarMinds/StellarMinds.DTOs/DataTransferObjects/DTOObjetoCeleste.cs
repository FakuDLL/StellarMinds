namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTOObjetoCeleste
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal MagnitudAparente { get; set; }
    }
}
