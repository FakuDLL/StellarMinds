using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.DTOs.Mappers
{
    public static class ObjetoCelesteMapper
    {
        public static DTOObjetoCeleste ToDto(ObjetoCeleste objetoCeleste)
        {
            return new DTOObjetoCeleste
            {
                Id = objetoCeleste.Id,
                Nombre = objetoCeleste.Nombre,
                Tipo = objetoCeleste.Tipo.ToString(),
                MagnitudAparente = objetoCeleste.MagnitudAparente
            };
        }

        public static List<DTOObjetoCeleste> ToDtoList(IEnumerable<ObjetoCeleste> objetosCelestes)
        {
            return objetosCelestes.Select(ToDto).ToList();
        }
    }
}
