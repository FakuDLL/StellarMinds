using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUDisponibilidadEquipo
    {
        DTODisponibilidadEquipo ObtenerDisponibilidad(string tipoEquipo, int equipoId);
    }
}
