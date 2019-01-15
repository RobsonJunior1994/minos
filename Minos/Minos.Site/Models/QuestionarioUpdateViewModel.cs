using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class QuestionarioUpdateViewModel
    {
        public int IdDoQuestionario { get; set; }
        public string NomeDoQuestionario { get; set; }
        public List<string> Perguntas { get; set; }
        public List<int> IdDePerguntas { get; set; }
    }
}
