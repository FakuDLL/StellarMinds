namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Telescopio : Equipo
    {
        public decimal AperturaMm { get; private set; }
        public decimal RelacionFocal { get; private set; }
        public decimal DistanciaFocalMm { get; private set; }
        public decimal PesoKg { get; private set; }

        private Telescopio()
        {
        }

        public Telescopio(
            string marca,
            string modelo,
            int cantidadDisponible,
            decimal aperturaMm,
            decimal relacionFocal,
            decimal distanciaFocalMm,
            decimal pesoKg)
            : base(marca, modelo, cantidadDisponible)
        {
            ActualizarDatosTecnicos(aperturaMm, relacionFocal, distanciaFocalMm, pesoKg);
        }

        public void ActualizarDatosTecnicos(
            decimal aperturaMm,
            decimal relacionFocal,
            decimal distanciaFocalMm,
            decimal pesoKg)
        {
            if (aperturaMm <= 0)
                throw new ArgumentException("La apertura (mm) debe ser mayor que cero.");

            if (relacionFocal <= 0)
                throw new ArgumentException("La relación focal debe ser mayor que cero.");

            if (distanciaFocalMm <= 0)
                throw new ArgumentException("La distancia focal (mm) debe ser mayor que cero.");

            if (pesoKg <= 0)
                throw new ArgumentException("El peso (kg) debe ser mayor que cero.");

            AperturaMm = aperturaMm;
            RelacionFocal = relacionFocal;
            DistanciaFocalMm = distanciaFocalMm;
            PesoKg = pesoKg;
        }
    }
}
