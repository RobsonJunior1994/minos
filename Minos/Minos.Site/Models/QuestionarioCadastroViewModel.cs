using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class QuestionarioCadastroViewModel
    {
        public string NomeDoQuestionario { get; set; }
        public DateTime PeriodoInicial { get; set; }
        public DateTime PeriodoFinal { get; set; }
        public List<int> ListaDeIdDePerguntas { get; set; }
    }
}
