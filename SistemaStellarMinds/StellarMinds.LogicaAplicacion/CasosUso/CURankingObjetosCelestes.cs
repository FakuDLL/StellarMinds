using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CURankingObjetosCelestes : ICURankingObjetosCelestes
    {
        private readonly IRepositorioObservacion _repositorioObservacion;

        public CURankingObjetosCelestes(IRepositorioObservacion repositorioObservacion)
        {
            _repositorioObservacion = repositorioObservacion;
        }

        public List<DTORankingObjetoCeleste> ObtenerRanking()
        {
            var ranking = _repositorioObservacion.ObtenerRankingObjetosCelestesObservados();
            return RankingObjetoCelesteMapper.ToDtoList(ranking);
        }
    }
}
