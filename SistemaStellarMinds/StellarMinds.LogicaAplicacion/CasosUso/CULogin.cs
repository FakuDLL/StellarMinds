using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.DTOs.Mappers;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaAplicacion.Utilidades;
using StellarMinds.LogicaNegocio.CustomException;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CULogin : ICULogin
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CULogin(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public DtoUsuarioLogueado Login(DtoLogin dtoLogin)
        {
            if (dtoLogin == null)
                throw new UsuarioInvalidoException("Los datos de login son obligatorios.");

            if (string.IsNullOrWhiteSpace(dtoLogin.NombreUsuario))
                throw new UsuarioInvalidoException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(dtoLogin.Password))
                throw new UsuarioInvalidoException("La contraseña es obligatoria.");

            var nombreUsuario = dtoLogin.NombreUsuario.Trim();

            var usuario = _repositorioUsuario.ObtenerPorNombreUsuario(nombreUsuario);

            if (usuario == null)
                throw new UsuarioInvalidoException("Usuario o contraseña incorrectos.");

            bool passwordValida = Crypto.Verify(dtoLogin.Password, usuario.PasswordHash);

            if (!passwordValida)
                throw new UsuarioInvalidoException("Usuario o contraseña incorrectos.");

            if (Crypto.NeedsRehash(usuario.PasswordHash))
            {
                usuario.ActualizarPasswordHash(Crypto.Hash(dtoLogin.Password));
                _repositorioUsuario.Actualizar(usuario);
            }

            return UsuarioMapper.ToDtoUsuarioLogueado(usuario);
        }
    }
}
