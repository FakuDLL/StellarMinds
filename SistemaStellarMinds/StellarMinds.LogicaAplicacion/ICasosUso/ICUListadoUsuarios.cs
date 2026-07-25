using StellarMinds.DTOs.DataTransferObjects;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface ICUListadoUsuarios
    {
        List<DTOUsuarioResumen> Listar(string? rol);
    }
}
