using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class RespostaRepository : IRespostaRepository
    {
        private MinosContext _context;

        public RespostaRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public void Salvar(int Resultado)
        {
            throw new NotImplementedException();
        }
    }
}
