using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class Round
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoria")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

        [Display(Name = "Candidatura")]
        public int CandidacyId { get; set; }
        public Candidacy Candidacy { get; set; }

        [Required]
        [Display(Name = "Periodo (yyyyMM)")]
        [StringLength(6)]
        public string Period { get; set; }
        
        public Boolean Closed { get; set; }

        public Round()
        {
            Closed = false;

            String month = DateTime.Now.Month.ToString();
            String year = DateTime.Now.Year.ToString();
            Period = year + month.PadLeft(2, '0'); 
        }
    }
}