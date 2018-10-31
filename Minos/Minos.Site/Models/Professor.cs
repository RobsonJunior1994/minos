using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Professor
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IList<ProfessorTurma> Turmas { get; set; }

        public Professor(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Turmas = new List<ProfessorTurma>();
        }

        public bool ValidaProfessor()
        { 
            if(string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Sobrenome)
                || Nome.Any(x => char.IsDigit(x)) || Sobrenome.Any(x => char.IsDigit(x))
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
