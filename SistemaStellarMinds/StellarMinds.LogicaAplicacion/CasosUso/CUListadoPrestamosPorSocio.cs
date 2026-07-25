using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUListadoPrestamosPorSocio : ICUListadoPrestamosPorSocio
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;

        public CUListadoPrestamosPorSocio(IRepositorioPrestamo repositorioPrestamo)
        {
            _repositorioPrestamo = repositorioPrestamo;
        }

        public List<DTOPrestamo> ListarPorSocioYEstado(int socioId, string estado)
        {
            if (socioId <= 0)
                throw new ArgumentException("El socio es obligatorio.");

            if (!Enum.TryParse<EstadoPrestamo>(estado, true, out var estadoPrestamo))
                throw new ArgumentException("El estado indicado no es válido.");

            var prestamos = _repositorioPrestamo.FindBySocioYEstado(socioId, estadoPrestamo);
            return PrestamoMapper.ToDtoList(prestamos);
        }
    }
}
