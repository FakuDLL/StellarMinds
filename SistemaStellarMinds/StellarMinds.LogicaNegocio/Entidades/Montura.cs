namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Montura : Equipo
    {
        public string TipoMontura { get; private set; } = string.Empty;
        public decimal CargaUtilKg { get; private set; }
        public bool EsComputarizado { get; private set; }

        private Montura()
        {
        }

        public Montura(
            string marca,
            string modelo,
            int cantidadDisponible,
            string tipoMontura,
            decimal cargaUtilKg,
            bool esComputarizado)
            : base(marca, modelo, cantidadDisponible)
        {
            ActualizarDatosTecnicos(tipoMontura, cargaUtilKg, esComputarizado);
        }

        public void ActualizarDatosTecnicos(string tipoMontura, decimal cargaUtilKg, bool esComputarizado)
        {
            if (string.IsNullOrWhiteSpace(tipoMontura))
                throw new ArgumentException("El tipo de montura es obligatorio.");

            if (cargaUtilKg <= 0)
                throw new ArgumentException("La carga útil (kg) debe ser mayor que cero.");

            TipoMontura = tipoMontura.Trim();
            CargaUtilKg = cargaUtilKg;
            EsComputarizado = esComputarizado;
        }
    }
}
