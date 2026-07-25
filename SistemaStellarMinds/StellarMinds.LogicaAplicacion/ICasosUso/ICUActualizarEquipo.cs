using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUActualizarEquipo
    {
        DTOActualizarEquipo ObtenerEquipoAActualizar(int id);
        void ActualizarEquipo(DTOActualizarEquipo dto);
    }
}
