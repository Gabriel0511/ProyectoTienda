﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.BD.Data.Entity
{
    public class Categoria : EntityBase
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        public string NombreCat { get; set; }
    }
}
