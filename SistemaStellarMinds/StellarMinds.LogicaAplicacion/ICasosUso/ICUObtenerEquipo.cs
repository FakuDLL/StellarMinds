using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUObtenerEquipo
    {
        DTOEquipo ObtenerPorId(int id);
    }
}
