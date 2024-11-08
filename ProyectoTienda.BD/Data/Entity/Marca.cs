﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.BD.Data.Entity
{
    public class Marca : EntityBase
    {
        [Required(ErrorMessage = "El nombre de la marca es obligatorio")]
        public string NombreMarca { get; set; }
    }
}
