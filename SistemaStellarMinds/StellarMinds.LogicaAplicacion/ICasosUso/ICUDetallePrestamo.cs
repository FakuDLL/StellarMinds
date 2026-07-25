using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUDetallePrestamo
    {
        DTOPrestamo ObtenerDetalle(int prestamoId);
    }
}
