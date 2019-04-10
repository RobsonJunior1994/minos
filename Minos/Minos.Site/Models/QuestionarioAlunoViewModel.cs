using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class QuestionarioAlunoViewModel
    {
        public string NomeDoAluno { get; set; }
        public string CodigoDaTurma { get; set; }
        public string Matricula { get; set; }
        public List<Professor> Professores { get; set; }
        public List<string> Perguntas { get; set; }
    }
}
