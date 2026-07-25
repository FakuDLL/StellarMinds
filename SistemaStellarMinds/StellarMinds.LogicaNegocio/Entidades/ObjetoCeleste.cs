using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class ObjetoCeleste
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public TipoObjetoCeleste Tipo { get; private set; }
        public decimal MagnitudAparente { get; private set; }

        private ObjetoCeleste()
        {
        }

        public ObjetoCeleste(string nombre, TipoObjetoCeleste tipo, decimal magnitudAparente)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del objeto celeste es obligatorio.");

            Nombre = nombre.Trim();
            Tipo = tipo;
            MagnitudAparente = decimal.Round(magnitudAparente, 2);
        }
    }
}
