using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.CustomException;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUAltaObservacion : ICUAltaObservacion
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;
        private readonly IRepositorioObjetoCeleste _repositorioObjetoCeleste;
        private readonly IRepositorioObservacion _repositorioObservacion;
        private readonly IEvaluadorObservacionIA _evaluadorObservacionIA;

        public CUAltaObservacion(
            IRepositorioPrestamo repositorioPrestamo,
            IRepositorioObjetoCeleste repositorioObjetoCeleste,
            IRepositorioObservacion repositorioObservacion,
            IEvaluadorObservacionIA evaluadorObservacionIA)
        {
            _repositorioPrestamo = repositorioPrestamo;
            _repositorioObjetoCeleste = repositorioObjetoCeleste;
            _repositorioObservacion = repositorioObservacion;
            _evaluadorObservacionIA = evaluadorObservacionIA;
        }

        public List<DTOPrestamo> ListarPrestamosVigentes(int socioId)
        {
            if (socioId <= 0)
                throw new ObservacionInvalidaException("El socio es obligatorio.");

            var hoy = DateTime.Today;
            var prestamos = _repositorioPrestamo
                .FindBySocioYEstado(socioId, EstadoPrestamo.EN_PRESTAMO)
                .Where(p => p.FechaInicio.Date <= hoy && p.FechaFin.Date >= hoy)
                .ToList();

            return PrestamoMapper.ToDtoList(prestamos);
        }

        public List<DTOObjetoCeleste> ListarObjetosCelestes()
        {
            return ObjetoCelesteMapper.ToDtoList(_repositorioObjetoCeleste.FindAll());
        }

        public DTOEvaluacionObservacion Evaluar(DTOEvaluarObservacion dto, int socioId)
        {
            if (dto == null)
                throw new ObservacionInvalidaException("Los datos de evaluación son obligatorios.");

            var prestamo = ObtenerPrestamoValido(dto.PrestamoId, socioId, dto.Fecha);
            var objetoCeleste = ObtenerObjetoCeleste(dto.ObjetoCelesteId);

            var evaluacion = _evaluadorObservacionIA.Evaluar(prestamo, objetoCeleste);
            ValidarEvaluacion(evaluacion);

            return evaluacion;
        }

        public DTOObservacion AltaObservacion(DTOAltaObservacion dto, int socioId)
        {
            if (dto == null)
                throw new ObservacionInvalidaException("Los datos de la observación son obligatorios.");

            var prestamo = ObtenerPrestamoValido(dto.PrestamoId, socioId, dto.Fecha);
            var objetoCeleste = ObtenerObjetoCeleste(dto.ObjetoCelesteId);
            var evaluacion = new DTOEvaluacionObservacion
            {
                Indicador = dto.Indicador,
                Detalle = dto.Detalle ?? string.Empty
            };
            ValidarEvaluacion(evaluacion);
            var indicador = ParsearIndicador(evaluacion.Indicador);

            var observacion = new Observacion(
                dto.Fecha,
                prestamo,
                objetoCeleste,
                indicador,
                evaluacion.Detalle ?? string.Empty);

            var id = _repositorioObservacion.Add(observacion);
            var guardada = _repositorioObservacion.FindById(id);

            if (guardada == null)
                throw new ObservacionInvalidaException("No se pudo recuperar la observación registrada.");

            return ObservacionMapper.ToDto(guardada);
        }

        private Prestamo ObtenerPrestamoValido(int prestamoId, int socioId, DateTime fechaObservacion)
        {
            if (prestamoId <= 0)
                throw new ObservacionInvalidaException("El préstamo es obligatorio.");

            if (socioId <= 0)
                throw new ObservacionInvalidaException("El socio es obligatorio.");

            if (fechaObservacion == default)
                throw new ObservacionInvalidaException("La fecha de observación es obligatoria.");

            var prestamo = _repositorioPrestamo.FindById(prestamoId);
            if (prestamo == null)
                throw new ObservacionInvalidaException("El préstamo indicado no existe.");

            if (prestamo.Socio.Id != socioId)
                throw new ObservacionInvalidaException("El préstamo no pertenece al socio autenticado.");

            if (prestamo.Estado != EstadoPrestamo.EN_PRESTAMO)
                throw new ObservacionInvalidaException("El préstamo debe estar en estado EN PRÉSTAMO.");

            var fecha = fechaObservacion.Date;
            if (fecha < prestamo.FechaInicio.Date || fecha > prestamo.FechaFin.Date)
                throw new ObservacionInvalidaException("El préstamo no está vigente para la fecha de observación.");

            if (prestamo.Camara == null && prestamo.Ocular == null)
                throw new ObservacionInvalidaException("El préstamo debe tener cámara u ocular para evaluar la observación.");

            return prestamo;
        }

        private ObjetoCeleste ObtenerObjetoCeleste(int objetoCelesteId)
        {
            if (objetoCelesteId <= 0)
                throw new ObservacionInvalidaException("El objeto celeste es obligatorio.");

            var objetoCeleste = _repositorioObjetoCeleste.FindById(objetoCelesteId);
            if (objetoCeleste == null)
                throw new ObservacionInvalidaException("El objeto celeste indicado no existe.");

            return objetoCeleste;
        }

        private static void ValidarEvaluacion(DTOEvaluacionObservacion evaluacion)
        {
            if (evaluacion == null)
                throw new ObservacionInvalidaException("No se pudo obtener la evaluación de IA.");

            var indicador = ParsearIndicador(evaluacion.Indicador);
            ValidarDetalle(indicador, evaluacion.Detalle ?? string.Empty);
        }

        private static IndicadorIA ParsearIndicador(string indicador)
        {
            var normalizado = (indicador ?? string.Empty)
                .Trim()
                .Replace(" ", "_")
                .Replace("-", "_")
                .ToUpperInvariant();

            if (!Enum.TryParse<IndicadorIA>(normalizado, out var resultado))
                throw new ObservacionInvalidaException("El indicador de evaluación no es válido.");

            return resultado;
        }

        private static void ValidarDetalle(IndicadorIA indicador, string detalle)
        {
            if (indicador != IndicadorIA.IDEAL && string.IsNullOrWhiteSpace(detalle))
                throw new ObservacionInvalidaException("El detalle de evaluación es obligatorio cuando el equipo no es ideal.");

            if ((detalle ?? string.Empty).Trim().Length > 300)
                throw new ObservacionInvalidaException("El detalle de evaluación no puede superar los 300 caracteres.");
        }
    }
}
