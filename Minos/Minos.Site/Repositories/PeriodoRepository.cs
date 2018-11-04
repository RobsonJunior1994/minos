using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class PeriodoRepository : IPeriodoRepository
    {
        public List<Periodo> ListarPeriodos()
        {
            using (var contexto = new MinosContext())
            {
                var periodos = contexto.Periodo.ToList();
                return periodos;
            }
        }

        public Periodo ObterPeriodoPeloId(int turmaId)
        {
            using (var contexto = new MinosContext())
            {
                var periodo = contexto.Periodo.First(x => x.Id == turmaId);
                return periodo;
            }
        }
    }
}
