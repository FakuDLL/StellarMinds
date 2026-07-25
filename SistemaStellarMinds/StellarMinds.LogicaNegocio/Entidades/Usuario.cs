using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.ValueObjects;

namespace StellarMinds.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string NombreCompleto { get; private set; } = string.Empty;
        public string Direccion { get; private set; } = string.Empty;
        public string Telefono { get; private set; } = string.Empty;
        public Email Email { get; private set; } = null!;
        public string NombreUsuario { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public RolUsuario Rol { get; private set; }

        private Usuario()
        {
        }

        public Usuario(
            string nombreCompleto,
            string direccion,
            string telefono,
            Email email,
            string nombreUsuario,
            string passwordHash,
            RolUsuario rol)
        {
            if (string.IsNullOrWhiteSpace(nombreCompleto))
                throw new ArgumentException("El nombre completo es obligatorio.");

            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección es obligatoria.");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("El hash de la contraseña es obligatorio.");

            NombreCompleto = nombreCompleto.Trim();
            Direccion = direccion.Trim();
            Telefono = telefono.Trim();
            Email = email;
            NombreUsuario = nombreUsuario.Trim();
            PasswordHash = passwordHash;
            Rol = rol;
        }

        public void ActualizarPasswordHash(string nuevoHash)
        {
            if (string.IsNullOrWhiteSpace(nuevoHash))
                throw new ArgumentException("El nuevo hash no puede ser vacío.");

            PasswordHash = nuevoHash;
        }
    }
}
