using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Consultas;

namespace StellarMinds.DTOs.Mappers
{
    public static class RankingObjetoCelesteMapper
    {
        public static DTORankingObjetoCeleste ToDto(RankingObjetoCeleste ranking)
        {
            return new DTORankingObjetoCeleste
            {
                ObjetoCelesteId = ranking.ObjetoCelesteId,
                Nombre = ranking.Nombre,
                Tipo = ranking.Tipo.ToString(),
                CantidadVecesObservado = ranking.CantidadVecesObservado
            };
        }

        public static List<DTORankingObjetoCeleste> ToDtoList(IEnumerable<RankingObjetoCeleste> ranking)
        {
            return ranking.Select(ToDto).ToList();
        }
    }
}
