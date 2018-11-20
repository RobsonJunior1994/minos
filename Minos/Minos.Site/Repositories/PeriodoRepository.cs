using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class PeriodoRepository : IPeriodoRepository
    {
        private MinosContext _context;

        public PeriodoRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public List<Periodo> ListarPeriodos()
        {
            var periodos = _context.Periodo.ToList();
            return periodos;
        }

        public Periodo ObterPeriodoPeloId(int turmaId)
        {
            var periodo = _context.Periodo.First(x => x.Id == turmaId);
            return periodo;
        }
    }
}
