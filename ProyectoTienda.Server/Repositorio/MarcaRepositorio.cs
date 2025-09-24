using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Repositorio
{
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly Context context;

        public MarcaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> Delete(int id)
        {
            var entidad = await context.Marcas.FindAsync(id);
            if (entidad == null) return 0;

            context.Marcas.Remove(entidad);
            return await context.SaveChangesAsync();
        }
    }
}
