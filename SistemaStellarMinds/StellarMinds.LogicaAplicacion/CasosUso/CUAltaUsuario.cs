using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaAplicacion.Utilidades;
using StellarMinds.LogicaNegocio.CustomException;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;
using StellarMinds.LogicaNegocio.ValueObjects;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CUAltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public DtoUsuarioLogueado AltaUsuario(DtoAltaUsuario dtoAltaUsuario)
        {
            if (dtoAltaUsuario == null)
                throw new UsuarioInvalidoException("Los datos del usuario son obligatorios.");

            if (string.IsNullOrWhiteSpace(dtoAltaUsuario.NombreCompleto))
                throw new UsuarioInvalidoException("El nombre completo es obligatorio.");

            if (string.IsNullOrWhiteSpace(dtoAltaUsuario.Direccion))
                throw new UsuarioInvalidoException("La dirección es obligatoria.");

            if (string.IsNullOrWhiteSpace(dtoAltaUsuario.Telefono))
                throw new UsuarioInvalidoException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(dtoAltaUsuario.NombreUsuario))
                throw new UsuarioInvalidoException("El nombre de usuario es obligatorio.");

            var email = new Email(dtoAltaUsuario.Email);
            var passwordPlano = new PasswordPlano(dtoAltaUsuario.Password);

            var usuarioExistente = _repositorioUsuario.ObtenerPorNombreUsuario(dtoAltaUsuario.NombreUsuario);
            if (usuarioExistente != null)
                throw new UsuarioInvalidoException("Ya existe un usuario con ese nombre de usuario.");

            var emailExistente = _repositorioUsuario.ObtenerPorEmail(email.Valor);
            if (emailExistente != null)
                throw new UsuarioInvalidoException("Ya existe un usuario con ese email.");

            if (!Enum.IsDefined(typeof(RolUsuario), dtoAltaUsuario.Rol))
                throw new UsuarioInvalidoException("El rol ingresado no es válido.");

            var rol = (RolUsuario)dtoAltaUsuario.Rol;
            var passwordHash = Crypto.Hash(passwordPlano.Valor);

            var nuevoUsuario = new Usuario(
                dtoAltaUsuario.NombreCompleto,
                dtoAltaUsuario.Direccion,
                dtoAltaUsuario.Telefono,
                email,
                dtoAltaUsuario.NombreUsuario,
                passwordHash,
                rol
            );

            _repositorioUsuario.Alta(nuevoUsuario);

            var usuarioGuardado = _repositorioUsuario.ObtenerPorNombreUsuario(dtoAltaUsuario.NombreUsuario);

            if (usuarioGuardado == null)
                throw new UsuarioInvalidoException("No se pudo recuperar el usuario luego del alta.");

            return UsuarioMapper.ToDtoUsuarioLogueado(usuarioGuardado);
        }
    }
}