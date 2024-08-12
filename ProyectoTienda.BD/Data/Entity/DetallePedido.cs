using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.BD.Data.Entity
{
    public class DetallePedido : EntityBase
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int ProductoId  { get; set; }
        public Producto Producto { get; set; }
        public int PedidoId { get; set; }
        public Pedido pedido { get; set; }
    }
}
