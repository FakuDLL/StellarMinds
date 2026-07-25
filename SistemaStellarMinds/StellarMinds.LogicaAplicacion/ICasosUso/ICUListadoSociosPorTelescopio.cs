using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUListadoSociosPorTelescopio
    {
        List<DTOUsuarioResumen> ListarSociosPorTelescopio(int telescopioId);
    }
}
