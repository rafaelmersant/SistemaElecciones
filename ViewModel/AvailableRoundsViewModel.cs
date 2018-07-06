using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaElecciones.Models
{
    public class AvailableRoundsViewModel
    {
        public IEnumerable<Round> Rounds { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Candidacy> Candidacies { get; set; }
    }
}