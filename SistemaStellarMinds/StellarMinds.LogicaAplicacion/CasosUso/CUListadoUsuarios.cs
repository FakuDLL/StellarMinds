using StellarMinds.DTOs.DataTransferObjects;
using StellarMinds.LogicaAplicacion.ICasosUso;
using StellarMinds.LogicaNegocio.Enums;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.LogicaAplicacion.CasosUso
{
    public class CUListadoUsuarios : ICUListadoUsuarios
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public CUListadoUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public List<DTOUsuarioResumen> Listar(string? rol)
        {
            var usuarios = _repositorioUsuario.Listar().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(rol))
            {
                if (!Enum.TryParse<RolUsuario>(rol, ignoreCase: true, out var rolUsuario))
                    throw new ArgumentException("Rol no válido.");

                usuarios = usuarios.Where(u => u.Rol == rolUsuario);
            }

            return usuarios.Select(u => new DTOUsuarioResumen
            {
                Id = u.Id,
                NombreCompleto = u.NombreCompleto,
                Email = u.Email.ToString(),
                NombreUsuario = u.NombreUsuario,
                Rol = u.Rol.ToString()
            }).ToList();
        }
    }
}
