namespace StellarMinds.LogicaNegocio.Entidades
{
    public abstract class Equipo
    {
        public int Id { get; protected set; }
        public string Marca { get; protected set; } = string.Empty;
        public string Modelo { get; protected set; } = string.Empty;
        public int CantidadDisponible { get; protected set; }

        protected Equipo()
        {
        }

        protected Equipo(string marca, string modelo, int cantidadDisponible)
        {
            AsignarMarca(marca);
            AsignarModelo(modelo);
            AsignarCantidadDisponible(cantidadDisponible);
        }

        public void ActualizarDatosBase(string marca, string modelo, int cantidadDisponible)
        {
            AsignarMarca(marca);
            AsignarModelo(modelo);
            AsignarCantidadDisponible(cantidadDisponible);
        }

        public void ReducirDisponibilidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a reducir debe ser mayor que cero.");

            if (CantidadDisponible < cantidad)
                throw new ArgumentException("No hay disponibilidad suficiente del equipo.");

            CantidadDisponible -= cantidad;
        }

        public void AumentarDisponibilidad(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a aumentar debe ser mayor que cero.");

            CantidadDisponible += cantidad;
        }

        private void AsignarMarca(string marca)
        {
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca es obligatoria.");

            Marca = marca.Trim();
        }

        private void AsignarModelo(string modelo)
        {
            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("El modelo es obligatorio.");

            Modelo = modelo.Trim();
        }

        private void AsignarCantidadDisponible(int cantidadDisponible)
        {
            if (cantidadDisponible < 0)
                throw new ArgumentException("La cantidad disponible no puede ser negativa.");

            CantidadDisponible = cantidadDisponible;
        }
    }
}
