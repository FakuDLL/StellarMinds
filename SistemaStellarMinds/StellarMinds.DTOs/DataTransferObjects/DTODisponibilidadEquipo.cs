namespace StellarMinds.DTOs.DataTransferObjects
{
    public class DTODisponibilidadEquipo
    {
        public int EquipoId { get; set; }
        public string TipoEquipo { get; set; } = string.Empty;
        public bool Disponible { get; set; }
        public int CantidadDisponible { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}
