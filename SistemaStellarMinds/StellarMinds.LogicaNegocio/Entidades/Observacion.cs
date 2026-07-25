using StellarMinds.LogicaNegocio.CustomException;
using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Observacion
    {
        public int Id { get; private set; }
        public DateTime Fecha { get; private set; }
        public int PrestamoId { get; private set; }
        public Prestamo Prestamo { get; private set; } = null!;
        public int ObjetoCelesteId { get; private set; }
        public ObjetoCeleste ObjetoCeleste { get; private set; } = null!;
        public IndicadorIA IndicadorIA { get; private set; }
        public string DetalleEvaluacion { get; private set; } = string.Empty;

        private Observacion()
        {
        }

        public Observacion(
            DateTime fecha,
            Prestamo prestamo,
            ObjetoCeleste objetoCeleste,
            IndicadorIA indicadorIA,
            string detalleEvaluacion)
        {
            if (fecha == default)
                throw new ObservacionInvalidaException("La fecha de observación es obligatoria.");

            Prestamo = prestamo ?? throw new ObservacionInvalidaException("El préstamo es obligatorio.");
            ObjetoCeleste = objetoCeleste ?? throw new ObservacionInvalidaException("El objeto celeste es obligatorio.");
            PrestamoId = Prestamo.Id;
            ObjetoCelesteId = ObjetoCeleste.Id;
            Fecha = fecha.Date;
            IndicadorIA = indicadorIA;
            DetalleEvaluacion = (detalleEvaluacion ?? string.Empty).Trim();

            if (DetalleEvaluacion.Length > 300)
                throw new ObservacionInvalidaException("El detalle de la evaluación no puede superar los 300 caracteres.");
        }
    }
}
