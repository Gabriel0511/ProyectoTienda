using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Repositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        Task<int> Delete(int id);
    }
}
