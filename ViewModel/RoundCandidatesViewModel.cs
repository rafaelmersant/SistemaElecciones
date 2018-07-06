using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class RoundCandidatesViewModel
    {
        public int RoundId { get; set; }
        public IEnumerable<Candidate> Candidates { get; set; }
    }
}