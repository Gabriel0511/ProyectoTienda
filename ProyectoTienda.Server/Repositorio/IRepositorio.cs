using ProyectoTienda.BD.Data;

namespace ProyectoTienda.Server.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<int> Insert(E dto);
        Task<List<E>> Select();
    }
}