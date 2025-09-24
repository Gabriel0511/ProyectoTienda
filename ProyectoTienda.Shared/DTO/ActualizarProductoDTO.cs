using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.Shared.DTO
{
    public class ActualizarProductoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string NombreProd { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public string Descripcion { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "El equipo no puede exceder los 50 caracteres")]
        public string Equipo { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "La liga no puede exceder los 50 caracteres")]
        public string Liga { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El talle es obligatorio")]
        public string Talle { get; set; } = string.Empty;

        [Required(ErrorMessage = "La cantidad en inventario es obligatoria")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
        public int CantidadEnInventario { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public int MarcaId { get; set; }
    }
}
