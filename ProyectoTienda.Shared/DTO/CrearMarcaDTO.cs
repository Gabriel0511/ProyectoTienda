using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.Shared.DTO
{
    public class CrearMarcaDTO
    {
        [Required(ErrorMessage = "El nombre de la marca es obligatorio")]
        public string NombreMarca { get; set; }
    }
}
