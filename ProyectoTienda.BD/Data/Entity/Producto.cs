using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.BD.Data.Entity
{
    public class Producto : EntityBase
    {
        public string NombreProd { get; set; }
        public string Descripcion { get; set; }
        public string Equipo { get; set; }
        public string Liga { get; set; }
        public decimal Precio { get; set; }
        public string Talle { get; set; }
        public int CantidadEnInventario { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
