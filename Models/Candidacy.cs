using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class Candidacy
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria.")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar una categoria.")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; } //Ejecutiva / Asoc. Damas / Asoc. Jovenes / Iglesia Local
        
        public Category Category { get; set; }
    }
}