namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Camara : Equipo
    {
        public string TipoSensor { get; private set; } = string.Empty;
        public string Resolucion { get; private set; } = string.Empty;
        public decimal TamanoPixelMicras { get; private set; }

        private Camara()
        {
        }

        public Camara(
            string marca,
            string modelo,
            int cantidadDisponible,
            string tipoSensor,
            string resolucion,
            decimal tamanoPixelMicras)
            : base(marca, modelo, cantidadDisponible)
        {
            ActualizarDatosTecnicos(tipoSensor, resolucion, tamanoPixelMicras);
        }

        public void ActualizarDatosTecnicos(string tipoSensor, string resolucion, decimal tamanoPixelMicras)
        {
            if (string.IsNullOrWhiteSpace(tipoSensor))
                throw new ArgumentException("El tipo de sensor es obligatorio.");

            if (string.IsNullOrWhiteSpace(resolucion))
                throw new ArgumentException("La resolución es obligatoria.");

            if (tamanoPixelMicras <= 0)
                throw new ArgumentException("El tamaño de pixel (micras) debe ser mayor que cero.");

            TipoSensor = tipoSensor.Trim();
            Resolucion = resolucion.Trim();
            TamanoPixelMicras = tamanoPixelMicras;
        }
    }
}
