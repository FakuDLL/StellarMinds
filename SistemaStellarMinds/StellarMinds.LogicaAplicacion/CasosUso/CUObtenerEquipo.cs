using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUObtenerEquipo : ICUObtenerEquipo
    {
        private readonly IRepositorioEquipo _repoEquipo;

        public CUObtenerEquipo(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public DTOEquipo ObtenerPorId(int id)
        {
            var equipo = _repoEquipo.FindById(id);
            if (equipo == null)
                throw new ArgumentException("No existe un equipo con ese Id.");

            return EquipoMapper.FromEquipoToDto(equipo);
        }
    }
}
