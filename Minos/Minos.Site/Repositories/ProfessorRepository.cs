using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        public void Salvar(Professor professor)
        {
            using (var contexto = new MinosContext())
            {
                contexto.Professores.Add(professor);
                contexto.SaveChanges();
            }
        }

        public List<Professor> ListarProfessores()
        {
            using (var contexto = new MinosContext())
            {
                var professores = contexto.Professores.ToList();
                return professores;
            }
        }
    }
}
