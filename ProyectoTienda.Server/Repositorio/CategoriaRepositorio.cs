using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly Context context;

        public CategoriaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> Delete(int id)
        {
            var entidad = await context.Categorias.FindAsync(id);
            if (entidad == null) return 0;

            context.Categorias.Remove(entidad);
            return await context.SaveChangesAsync();
        }
    }
}
