using Microsoft.EntityFrameworkCore;
using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private MinosContext _context;

        public TurmaRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public void Atualizar(Turma turma)
        {
            _context.Update(turma);
            _context.SaveChanges();
        }

        public List<Turma> ListarTurmas()
        {
            var turmas = _context.Turmas.Where(x => x.Ativo == true).ToList();
            return turmas;
        }

        public Turma ObterTurmaPeloId(int turmaId)
        {
            var turma = _context.Turmas.FirstOrDefault(x => x.Id == turmaId);
            return turma;
        }

        public List<Turma> ObterTurmasDesteAno()
        {
            throw new NotImplementedException();
        }

        public void Salvar(Turma turma)
        {
            _context.Turmas.Add(turma);
            _context.SaveChanges();

        }

        public void Salvar(string CodigoTurma)
        {
            throw new NotImplementedException();
        }
    }
}


