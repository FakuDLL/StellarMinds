using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.IRepositorios
{
    public interface IRepositorioUsuario
    {
        Usuario? ObtenerPorId(int id);
        Usuario? ObtenerPorNombreUsuario(string nombreUsuario);
        Usuario? ObtenerPorEmail(string email);
        List<Usuario> Listar();
        void Alta(Usuario usuario);
        void Actualizar(Usuario usuario);
    }
}
