using Microsoft.EntityFrameworkCore;
using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {


        private MinosContext _context;

        public ProfessorRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public void Salvar(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
        }

        public List<Professor> ListarProfessores()
        {
            var professores = _context
                .Professores
                .Include(p => p.Turmas)
                .ThenInclude(pt => pt.Turma)
                .Where(x => x.Ativo == true).ToList();
            return professores;
        }

        public Professor ObterProfessorPeloId(int id)
        {
            var professor = _context.Professores.Include(x => x.Turmas).FirstOrDefault(p => p.Id == id);
            return professor;
        }

        public void Excluir(int id)
        {
            var professor = _context.Professores.Where(p => p.Id == id).First();
            _context.Professores.Remove(professor);
            _context.SaveChanges();
        }

        public void Atualizar(Professor professor)
        {
            _context.Professores.Update(professor);
            _context.SaveChanges();

        }
    }
}
