using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class CandidacyViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Candidacy Candidacy { get; set; }
    }
}