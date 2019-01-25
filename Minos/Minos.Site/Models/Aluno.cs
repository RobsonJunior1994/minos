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

        public Aluno (string nome, string sobrenome, Turma turma)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Turma = turma;
        }

        public Aluno() { }
    }
}
