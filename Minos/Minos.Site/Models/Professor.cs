using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Professor
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IList<Turma> Turmas { get; set; }
    }
}
