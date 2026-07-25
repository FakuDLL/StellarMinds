using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUDetallePrestamo : ICUDetallePrestamo
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;

        public CUDetallePrestamo(IRepositorioPrestamo repositorioPrestamo)
        {
            _repositorioPrestamo = repositorioPrestamo;
        }

        public DTOPrestamo ObtenerDetalle(int prestamoId)
        {
            if (prestamoId <= 0)
                throw new ArgumentException("El préstamo es obligatorio.");

            var prestamo = _repositorioPrestamo.FindById(prestamoId);
            if (prestamo == null)
                throw new ArgumentException("No existe un préstamo con ese Id.");

            return PrestamoMapper.ToDto(prestamo);
        }
    }
}
