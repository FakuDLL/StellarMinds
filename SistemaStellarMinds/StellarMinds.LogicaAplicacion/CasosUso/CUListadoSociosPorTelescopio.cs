using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUListadoSociosPorTelescopio : ICUListadoSociosPorTelescopio
    {
        private readonly IRepositorioPrestamo _repositorioPrestamo;

        public CUListadoSociosPorTelescopio(IRepositorioPrestamo repositorioPrestamo)
        {
            _repositorioPrestamo = repositorioPrestamo;
        }

        public List<DTOUsuarioResumen> ListarSociosPorTelescopio(int telescopioId)
        {
            if (telescopioId <= 0)
                throw new ArgumentException("El telescopio es obligatorio.");

            var socios = _repositorioPrestamo.FindSociosPorTelescopio(telescopioId);
            return UsuarioMapper.ToDtoResumenList(socios);
        }
    }
}
