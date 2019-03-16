using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private MinosContext _context;

        public AlunoRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public Aluno ObterAlunoPorMatricula(string matriculaDoAluno)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Matricula == matriculaDoAluno);
            return aluno;
        }

        public void Salvar(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
        }
    }
}