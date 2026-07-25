using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUObtenerEquipos : ICUObtenerEquipos
    {
        private readonly IRepositorioEquipo _repoEquipo;

        public CUObtenerEquipos(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public List<DTOEquipo> ObtenerEquipos()
        {
            var equipos = _repoEquipo.FindAll();
            return EquipoMapper.FromListEquipoToListDto(equipos);
        }
    }
}
