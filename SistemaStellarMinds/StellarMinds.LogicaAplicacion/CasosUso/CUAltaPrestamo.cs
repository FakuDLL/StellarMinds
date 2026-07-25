using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.CustomException;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUAltaPrestamo : ICUAltaPrestamo
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioEquipo _repositorioEquipo;
        private readonly IRepositorioPrestamo _repositorioPrestamo;
        private readonly IRepositorioAuditoriaPrestamo _repositorioAuditoriaPrestamo;

        public CUAltaPrestamo(
            IRepositorioUsuario repositorioUsuario,
            IRepositorioEquipo repositorioEquipo,
            IRepositorioPrestamo repositorioPrestamo,
            IRepositorioAuditoriaPrestamo repositorioAuditoriaPrestamo)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioEquipo = repositorioEquipo;
            _repositorioPrestamo = repositorioPrestamo;
            _repositorioAuditoriaPrestamo = repositorioAuditoriaPrestamo;
        }

        public int AltaPrestamo(DTOAltaPrestamo dto, int coordinadorId)
        {
            if (dto == null)
                throw new PrestamoInvalidoException("Los datos del préstamo son obligatorios.");

            if (dto.FechaInicio == default)
                throw new PrestamoInvalidoException("La fecha de inicio es obligatoria.");

            if (dto.FechaFin == default)
                throw new PrestamoInvalidoException("La fecha de fin es obligatoria.");

            if (dto.FechaFin < dto.FechaInicio)
                throw new PrestamoInvalidoException("La fecha de fin debe ser posterior o igual a la fecha de inicio.");

            if (dto.TelescopioId <= 0)
                throw new PrestamoInvalidoException("El telescopio es obligatorio.");

            if (dto.MonturaId <= 0)
                throw new PrestamoInvalidoException("La montura es obligatoria.");

            if (dto.SocioId <= 0)
                throw new PrestamoInvalidoException("El socio es obligatorio.");

            if (!dto.CamaraId.HasValue && !dto.OcularId.HasValue)
                throw new PrestamoInvalidoException("Debe seleccionar al menos una cámara u ocular.");

            var socio = _repositorioUsuario.ObtenerPorId(dto.SocioId);
            if (socio == null)
                throw new PrestamoInvalidoException("El socio indicado no existe.");

            var coordinador = _repositorioUsuario.ObtenerPorId(coordinadorId);
            if (coordinador == null)
                throw new PrestamoInvalidoException("El coordinador indicado no existe.");

            var telescopio = _repositorioEquipo.FindById(dto.TelescopioId) as Telescopio;
            if (telescopio == null)
                throw new PrestamoInvalidoException("El telescopio indicado no existe.");

            var montura = _repositorioEquipo.FindById(dto.MonturaId) as Montura;
            if (montura == null)
                throw new PrestamoInvalidoException("La montura indicada no existe.");

            Camara? camara = null;
            if (dto.CamaraId.HasValue)
            {
                camara = _repositorioEquipo.FindById(dto.CamaraId.Value) as Camara;
                if (camara == null)
                    throw new PrestamoInvalidoException("La cámara indicada no existe.");
            }

            Ocular? ocular = null;
            if (dto.OcularId.HasValue)
            {
                ocular = _repositorioEquipo.FindById(dto.OcularId.Value) as Ocular;
                if (ocular == null)
                    throw new PrestamoInvalidoException("El ocular indicado no existe.");
            }

            if (telescopio.CantidadDisponible <= 0)
                throw new EquipoSinDisponibilidadException("El telescopio no tiene disponibilidad.");

            if (montura.CantidadDisponible <= 0)
                throw new EquipoSinDisponibilidadException("La montura no tiene disponibilidad.");

            if (camara != null && camara.CantidadDisponible <= 0)
                throw new EquipoSinDisponibilidadException("La cámara no tiene disponibilidad.");

            if (ocular != null && ocular.CantidadDisponible <= 0)
                throw new EquipoSinDisponibilidadException("El ocular no tiene disponibilidad.");

            if (montura.CargaUtilKg < telescopio.PesoKg)
                throw new CompatibilidadEquiposException("La montura no soporta el peso del telescopio.");

            if (camara != null)
            {
                if (!EsMonturaCompatibleParaCamara(montura))
                    throw new CompatibilidadEquiposException("La montura debe ser ecuatorial o híbrida para usar cámara.");
            }

            var prestamo = new Prestamo(
                dto.FechaInicio,
                dto.FechaFin,
                socio,
                telescopio,
                montura,
                camara,
                ocular);

            telescopio.ReducirDisponibilidad(1);
            montura.ReducirDisponibilidad(1);
            if (camara != null)
                camara.ReducirDisponibilidad(1);
            if (ocular != null)
                ocular.ReducirDisponibilidad(1);

            _repositorioEquipo.Update(telescopio);
            _repositorioEquipo.Update(montura);
            if (camara != null)
                _repositorioEquipo.Update(camara);
            if (ocular != null)
                _repositorioEquipo.Update(ocular);

            var prestamoId = _repositorioPrestamo.Add(prestamo);
            var auditoria = new AuditoriaPrestamo(AccionPrestamo.ALTA, prestamo, coordinador);
            _repositorioAuditoriaPrestamo.Add(auditoria);

            return prestamoId;
        }

        private static bool EsMonturaCompatibleParaCamara(Montura montura)
        {
            if (Enum.TryParse<TipoMontura>(montura.TipoMontura, true, out var tipo))
            {
                return tipo == TipoMontura.Ecuatorial || tipo == TipoMontura.Hibrida;
            }

            var tipoTexto = montura.TipoMontura?.Trim().ToLowerInvariant();
            return tipoTexto == "ecuatorial" || tipoTexto == "hibrida" || tipoTexto == "híbrida";
        }
    }
}
