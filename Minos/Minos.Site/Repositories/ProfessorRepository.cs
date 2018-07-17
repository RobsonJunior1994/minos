using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly MinosContext _context;

        public ProfessorRepository(MinosContext minosContext)
        {
            _context = minosContext;
        }

        public void Salvar(Professor professor)
        {
            throw new NotImplementedException();
        }
    }
}
