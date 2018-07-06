using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class RoundDetailsCandidatesViewModel
    {
        public IEnumerable<RoundDetail> RoundDetails { get; set; }
        public IEnumerable<Candidate> Candidates { get; set; }
    }
}