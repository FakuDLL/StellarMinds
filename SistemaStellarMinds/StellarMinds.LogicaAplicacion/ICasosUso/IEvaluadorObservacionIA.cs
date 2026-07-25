using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaAplicacion.ICasosUso
{
    public interface IEvaluadorObservacionIA
    {
        DTOEvaluacionObservacion Evaluar(Prestamo prestamo, ObjetoCeleste objetoCeleste);
    }
}
