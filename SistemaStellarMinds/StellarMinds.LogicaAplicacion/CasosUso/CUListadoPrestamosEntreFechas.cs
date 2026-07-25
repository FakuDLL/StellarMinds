using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUListadoPrestamosEntreFechas : ICUListadoPrestamosEntreFechas
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;

        public CUListadoPrestamosEntreFechas(IRepositorioPrestamo repositorioPrestamo)
        {
            _repositorioPrestamo = repositorioPrestamo;
        }

        public List<DTOPrestamoConAtraso> ListarPorSocioMesAnio(int socioId, int mes, int anio)
        {
            if (socioId <= 0)
                throw new ArgumentException("El socio autenticado es obligatorio.");

            if (mes < 1 || mes > 12)
                throw new ArgumentException("El mes debe estar entre 1 y 12.");

            if (anio < 1)
                throw new ArgumentException("El año indicado no es válido.");

            var prestamos = _repositorioPrestamo.FindBySocioYMesAnio(socioId, mes, anio);
            return PrestamoMapper.ToDtoConAtrasoList(prestamos, DateTime.Today);
        }
    }
}
