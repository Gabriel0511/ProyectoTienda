using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Repositorio
{
    public interface IMarcaRepositorio : IRepositorio<Marca>
    {
        Task<int> Delete(int id);
    }
}
