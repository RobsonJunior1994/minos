using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class QuestionarioTurma
    {
        public int QuestionarioId { get; set; }
        public virtual Questionario Questionario { get; set; }

        public int TurmaId { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
