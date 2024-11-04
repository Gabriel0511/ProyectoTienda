using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.Shared.DTO
{
    public class CrearCategoriaDTO
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        public string NombreCat { get; set; }
    }
}
