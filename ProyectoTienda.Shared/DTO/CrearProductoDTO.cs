using System.ComponentModel.DataAnnotations;

namespace ProyectoTienda.BD.Data.DTOs
{
    public class CrearProductoDTO
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string NombreProd { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(250, ErrorMessage = "La descripción no puede superar los 250 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El equipo es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre del equipo no puede superar los 50 caracteres")]
        public string Equipo { get; set; }

        [Required(ErrorMessage = "La liga es obligatoria")]
        [StringLength(50, ErrorMessage = "El nombre de la liga no puede superar los 50 caracteres")]
        public string Liga { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El talle es obligatorio")]
        [StringLength(5, ErrorMessage = "El talle no puede superar los 5 caracteres")]
        public string Talle { get; set; }

        [Required(ErrorMessage = "La cantidad en inventario es obligatoria")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en inventario no puede ser negativa")]
        public int CantidadEnInventario { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int CategoriaId { get; set; }
    }
}
