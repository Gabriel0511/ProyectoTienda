using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTienda.BD.Data.Entity
{
    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del producto no debe exceder los 100 caracteres")]
        public string NombreProd { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no debe exceder los 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El equipo es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del equipo no debe exceder los 50 caracteres")]
        public string Equipo { get; set; }

        [Required(ErrorMessage = "La liga es obligatoria")]
        [StringLength(50, ErrorMessage = "El nombre de la liga no debe exceder los 50 caracteres")]
        public string Liga { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El talle es obligatorio")]
        [StringLength(5, ErrorMessage = "El talle no debe exceder los 5 caracteres")]
        public string Talle { get; set; }

        [Required(ErrorMessage = "La cantidad en inventario es obligatoria")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en inventario debe ser un número positivo")]
        public int CantidadEnInventario { get; set; }

        public int MarcaId { get; set; }

        public Marca Marca { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}
