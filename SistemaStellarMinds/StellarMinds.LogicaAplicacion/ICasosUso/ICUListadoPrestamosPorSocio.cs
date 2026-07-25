using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUListadoPrestamosPorSocio
    {
        List<DTOPrestamo> ListarPorSocioYEstado(int socioId, string estado);
    }
}
