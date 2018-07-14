using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public Grau Grau { get; set; }
        public IList<Professor> Professores { get; set; }
    }
}
