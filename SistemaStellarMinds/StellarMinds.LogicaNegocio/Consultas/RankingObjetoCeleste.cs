using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.LogicaNegocio.Consultas
{
    public class RankingObjetoCeleste
    {
        public int ObjetoCelesteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public TipoObjetoCeleste Tipo { get; set; }
        public int CantidadVecesObservado { get; set; }
    }
}
