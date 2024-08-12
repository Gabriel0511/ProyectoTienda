using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.BD.Data.Entity
{
    public class Pedido : EntityBase
    {
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string EstadoDelPedido { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
