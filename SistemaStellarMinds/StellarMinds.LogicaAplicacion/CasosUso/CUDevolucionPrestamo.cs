using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.CustomException;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUDevolucionPrestamo : ICUDevolucionPrestamo
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;
        private readonly IRepositorioEquipo _repositorioEquipo;
        private readonly IRepositorioAuditoriaPrestamo _repositorioAuditoriaPrestamo;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CUDevolucionPrestamo(
            IRepositorioPrestamo repositorioPrestamo,
            IRepositorioEquipo repositorioEquipo,
            IRepositorioAuditoriaPrestamo repositorioAuditoriaPrestamo,
            IRepositorioUsuario repositorioUsuario)
        {
            _repositorioPrestamo = repositorioPrestamo;
            _repositorioEquipo = repositorioEquipo;
            _repositorioAuditoriaPrestamo = repositorioAuditoriaPrestamo;
            _repositorioUsuario = repositorioUsuario;
        }

        public void DevolverPrestamo(int prestamoId, int coordinadorId)
        {
            if (prestamoId <= 0)
                throw new PrestamoInvalidoException("El préstamo es obligatorio.");

            var prestamo = _repositorioPrestamo.FindById(prestamoId);
            if (prestamo == null)
                throw new PrestamoInvalidoException("El préstamo indicado no existe.");

            if (prestamo.Estado == EstadoPrestamo.DEVUELTO)
                throw new PrestamoInvalidoException("El préstamo ya fue devuelto.");

            var coordinador = _repositorioUsuario.ObtenerPorId(coordinadorId);
            if (coordinador == null)
                throw new PrestamoInvalidoException("El coordinador indicado no existe.");

            prestamo.Devolver();

            prestamo.Telescopio.AumentarDisponibilidad(1);
            prestamo.Montura.AumentarDisponibilidad(1);
            if (prestamo.Camara != null)
                prestamo.Camara.AumentarDisponibilidad(1);
            if (prestamo.Ocular != null)
                prestamo.Ocular.AumentarDisponibilidad(1);

            _repositorioEquipo.Update(prestamo.Telescopio);
            _repositorioEquipo.Update(prestamo.Montura);
            if (prestamo.Camara != null)
                _repositorioEquipo.Update(prestamo.Camara);
            if (prestamo.Ocular != null)
                _repositorioEquipo.Update(prestamo.Ocular);

            _repositorioPrestamo.Update(prestamo);

            var auditoria = new AuditoriaPrestamo(AccionPrestamo.DEVOLUCION, prestamo, coordinador);
            _repositorioAuditoriaPrestamo.Add(auditoria);
        }
    }
}
