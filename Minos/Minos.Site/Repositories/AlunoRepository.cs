using Microsoft.EntityFrameworkCore;
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
            var aluno = _context.Alunos
                .Include(a => a.Turma)
                .ThenInclude(t => t.Professores)
                .Include(t => t.Turma)
                .ThenInclude(q => q.Questionarios)
                .FirstOrDefault(x => x.Matricula == matriculaDoAluno);
                
            return aluno;
        }

        public void Salvar(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
        }
    }
}