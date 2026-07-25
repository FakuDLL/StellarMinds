using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.DTOs.Mappers
{
    public static class ObservacionMapper
    {
        public static DTOObservacion ToDto(Observacion observacion)
        {
            return new DTOObservacion
            {
                Id = observacion.Id,
                PrestamoId = observacion.PrestamoId,
                ObjetoCelesteId = observacion.ObjetoCelesteId,
                ObjetoCelesteNombre = observacion.ObjetoCeleste.Nombre,
                Fecha = observacion.Fecha,
                Indicador = observacion.IndicadorIA.ToString(),
                Detalle = observacion.DetalleEvaluacion
            };
        }
    }
}
