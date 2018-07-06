using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe especificar un nombre.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Candidatura")]
        public int CandidacyId { get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar una foto.")]
        [Display(Name = "Foto")]
        public string photoUrl { get; set; }

        [Display(Name = "Periodo (yyyyMM)")]
        [StringLength(6)]
        public string Period { get; set; }

        public Candidacy Candidacy { get; set; }

        public Candidate()
        {
            String month = DateTime.Now.Month.ToString();
            String year  = DateTime.Now.Year.ToString();
            Period = year + month.PadLeft(2, '0'); 
        }
    }
}