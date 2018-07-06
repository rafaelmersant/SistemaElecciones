using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class RoundDetail
    {
        public int Id { get; set; }
        
        [Required]
        public int IdHeader { get; set; }
        
        public Candidate Candidate { get; set; }

        [Required]
        public int CandidateId { get; set; }
        
        public int Votes { get; set; }
        
    }
}