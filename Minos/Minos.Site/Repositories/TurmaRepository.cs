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
        public List<Turma> ListarTurmas()
        {
            using (var contexto = new MinosContext())
            {
                var turmas = contexto.Turmas.ToList();
                return turmas;
            }

        }

        public Turma ObterTurmaPeloId(int turmaId)
        {
            using (var contexto = new MinosContext())
            {
                var turma = contexto.Turmas.FirstOrDefault(x => x.Id == turmaId);
                return turma;
            }
        }

        public List<Turma> ObterTurmasDesteAno()
        {
            throw new NotImplementedException();
        }

        public void Salvar(Turma turma)
        {
            using (var contexto = new MinosContext())
            {
                contexto.Turmas.Add(turma);
                contexto.SaveChanges();
            }
            
        }

        public void Salvar(string CodigoTurma)
        {
            throw new NotImplementedException();
        }
    }
}


