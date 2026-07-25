using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUAltaPrestamo
    {
        int AltaPrestamo(DTOAltaPrestamo dto, int coordinadorId);
    }
}
