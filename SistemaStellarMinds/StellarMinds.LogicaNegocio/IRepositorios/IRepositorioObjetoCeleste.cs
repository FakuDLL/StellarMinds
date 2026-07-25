using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.LogicaNegocio.IRepositorios
{
    public interface IRepositorioObjetoCeleste
    {
        List<ObjetoCeleste> FindAll();
        ObjetoCeleste? FindById(int id);
    }
}
