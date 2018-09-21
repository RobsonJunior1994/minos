using Minos.Site.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Aluno : Usuario
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public Turma Turma { get; set; }


        public Aluno(string nome, string sobrenome, Turma turma)
        {
            Nome = nome;
            SobreNome = sobrenome;
            Turma = turma;
        }
    }
}
