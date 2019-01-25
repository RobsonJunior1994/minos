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

        public void Atualizar(string Matricula)
        {
            throw new NotImplementedException();
        }

        public void Desativar(string matricula)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ListaDeAlunos()
        {
            throw new NotImplementedException();
        }

        public Aluno ObterAlunoPorMatricula(string matriculaDoAluno)
        {
            var aluno = _context.Aluno.Where(x => x.Matricula == matriculaDoAluno).First();
            return aluno;
        }

        public void Salvar(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
        }
    }
}
