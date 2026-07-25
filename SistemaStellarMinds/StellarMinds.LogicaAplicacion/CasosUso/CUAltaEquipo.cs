using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUAltaEquipo : ICUAltaEquipo
    {
        private readonly IRepositorioEquipo _repoEquipo;

        public CUAltaEquipo(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public int AltaEquipo(DTOAltaEquipo dto)
        {
            if (dto == null)
                throw new ArgumentException("Los datos del equipo son obligatorios.");

            var equipo = EquipoMapper.FromDtoAltaToEquipo(dto);
            return _repoEquipo.Add(equipo);
        }
    }
}
