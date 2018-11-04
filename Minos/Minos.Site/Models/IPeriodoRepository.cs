
using System.Collections.Generic;

namespace Minos.Site.Models
{
    public interface IPeriodoRepository
    {
        List<Periodo> ListarPeriodos();
        Periodo ObterPeriodoPeloId(int turmaId);
    }
}