using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUDetalleAuditoriaPrestamo
    {
        DTOAuditoriaPrestamo ObtenerDetalle(int auditoriaId);
    }
}
