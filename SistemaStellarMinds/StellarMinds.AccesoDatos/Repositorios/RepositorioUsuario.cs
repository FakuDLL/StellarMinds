
using Microsoft.EntityFrameworkCore;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.IRepositorios;

namespace StellarMinds.AccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Alta(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public Usuario? ObtenerPorNombreUsuario(string nombreUsuario)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Id == id);
        }

        public Usuario? ObtenerPorEmail(string email)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Email.Valor == email);
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios
                .OrderBy(u => u.NombreCompleto)
                .ToList();
        }
    }
}
