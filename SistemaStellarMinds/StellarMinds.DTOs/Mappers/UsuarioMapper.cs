using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.DTOs.Mappers
{
    public static class UsuarioMapper
    {
        public static DtoUsuarioLogueado ToDtoUsuarioLogueado(Usuario usuario)
        {
            return new DtoUsuarioLogueado
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                Email = usuario.Email.ToString(),
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol.ToString()
            };
        }

        public static DTOUsuarioResumen ToDtoResumen(Usuario usuario)
        {
            return new DTOUsuarioResumen
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                Email = usuario.Email.ToString(),
                NombreUsuario = usuario.NombreUsuario,
                Rol = usuario.Rol.ToString()
            };
        }

        public static List<DTOUsuarioResumen> ToDtoResumenList(IEnumerable<Usuario> usuarios)
        {
            return usuarios.Select(ToDtoResumen).ToList();
        }
    }
}
