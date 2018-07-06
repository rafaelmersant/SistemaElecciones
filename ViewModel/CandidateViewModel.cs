using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class CandidateViewModel
    {
        public IEnumerable<Candidacy> Candidacies { get; set; }
        public Candidate Candidate { get; set; }
    }
}