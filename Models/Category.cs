using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaElecciones.Models
{
    //The category are: Ejecutiva / Asoc. Damas / Asoc. Caballeros / Asoc. Jovenes / Iglesia Local
    public class Category
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Debe completar la descripcion.")]
        [StringLength(50)]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
    }
}