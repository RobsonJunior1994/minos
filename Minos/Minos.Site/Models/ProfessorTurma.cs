using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class ProfessorTurma
    {
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
