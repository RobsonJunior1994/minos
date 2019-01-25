using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Turma Turma { get; set; }
        public string Matricula { get; set; }

        public Aluno () { }

        public Aluno (string nome, string sobrenome, Turma turma)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Turma = turma;
        }

        internal bool EhValido()
        {
            if(String.IsNullOrEmpty(Nome) || String.IsNullOrEmpty(Sobrenome) ||
                !Turma.EhValida() || String.IsNullOrEmpty(Matricula))
            {
                return false;
            }

            return true;
        }
    }
}
