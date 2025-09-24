using System.ComponentModel.DataAnnotations;

namespace ProyectoTienda.Shared.DTO
{
    public class CrearMarcaDTO
    {
        [Required(ErrorMessage = "El nombre de la marca es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string NombreMarca { get; set; } = string.Empty;
    }
}