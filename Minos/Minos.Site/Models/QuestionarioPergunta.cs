using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class QuestionarioPergunta
    {
        public int QuestionarioId { get; set; }
        public Questionario Questionario { get; set; }

        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }
    }
}
