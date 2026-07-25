using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Consultas;

namespace StellarMinds.LogicaNegocio.IRepositorios
{
    public interface IRepositorioObservacion
    {
        int Add(Observacion observacion);
        Observacion? FindById(int id);
        List<RankingObjetoCeleste> ObtenerRankingObjetosCelestesObservados();
    }
}
