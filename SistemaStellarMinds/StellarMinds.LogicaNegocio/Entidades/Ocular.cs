namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Ocular : Equipo
    {
        public decimal DiametroMm { get; private set; }
        public decimal AnguloVisionGrados { get; private set; }

        private Ocular()
        {
        }

        public Ocular(
            string marca,
            string modelo,
            int cantidadDisponible,
            decimal diametroMm,
            decimal anguloVisionGrados)
            : base(marca, modelo, cantidadDisponible)
        {
            ActualizarDatosTecnicos(diametroMm, anguloVisionGrados);
        }

        public void ActualizarDatosTecnicos(decimal diametroMm, decimal anguloVisionGrados)
        {
            if (diametroMm <= 0)
                throw new ArgumentException("El diámetro (mm) debe ser mayor que cero.");

            if (anguloVisionGrados <= 0)
                throw new ArgumentException("El ángulo de visión (grados) debe ser mayor que cero.");

            DiametroMm = diametroMm;
            AnguloVisionGrados = anguloVisionGrados;
        }
    }
}
