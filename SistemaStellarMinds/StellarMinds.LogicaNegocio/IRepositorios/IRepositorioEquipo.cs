using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.IRepositorios
{
    public interface IRepositorioEquipo
    {
        int Add(Equipo equipo);
        List<Equipo> FindAll();
        Equipo? FindById(int id);
        void Update(Equipo equipo);
        void Remove(Equipo equipo);
    }
}
