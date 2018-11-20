using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {

        private MinosContext _context;

        public PerguntaRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public List<Pergunta> ListarPergunras()
        {
            var perguntas = _context.Perguntas.ToList();
            return perguntas;

        }

        public Pergunta ObterPerguntaPeloId(int turmaId)
        {
            var pergunta = _context.Perguntas.First(x => x.Id == turmaId);
            return pergunta;
        }

        public void Salvar(Pergunta pergunta)
        {
            _context.Add(pergunta);
            _context.SaveChanges();

        }
    }
}
