using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUListadoAuditoriaPrestamos
    {
        List<DTOAuditoriaPrestamo> Listar();
        List<DTOAuditoriaPrestamo> ListarPorCoordinador(int coordinadorId);
        List<DTOAuditoriaPrestamo> ListarPorPrestamo(int prestamoId);
    }
}
