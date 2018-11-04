using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {
        public List<Pergunta> ListarPergunras()
        {
            using (var contexto = new MinosContext())
            {
                var perguntas = contexto.Perguntas.ToList();
                return perguntas;
            }
        }

        public Pergunta ObterPerguntaPeloId(int turmaId)
        {
            using (var contexto = new MinosContext())
            {
                var pergunta = contexto.Perguntas.First(x => x.Id == turmaId);
                return pergunta;
            }
        }

        public void Salvar(Pergunta pergunta)
        {
            using (var contexto = new MinosContext())
            {
                contexto.Add(pergunta);
                contexto.SaveChanges();
            }
        }
    }
}
