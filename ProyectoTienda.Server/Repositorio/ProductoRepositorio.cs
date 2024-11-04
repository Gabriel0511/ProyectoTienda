using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly Context context;

        public ProductoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
