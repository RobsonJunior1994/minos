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
        //private List<Pergunta> _perguntas;

        public PerguntaRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public void Deletar(int id)
        {
            var pergunta = ObterPerguntaPeloId(id);
            _context.Perguntas.Remove(pergunta);
            _context.SaveChanges();
        }

        //public List<Pergunta> ListarPerguntas()
        //{
        //    var perguntas = _context.Perguntas.ToList();
        //    List<Pergunta> _perguntas = null; 
        //    foreach (var item in perguntas)
        //    {
        //        if(item.Ativo == true)
        //        {
        //            _perguntas.Add(item);
        //        }
        //    }
        //    return _perguntas;
        //}

        public List<Pergunta> ListarPerguntas()
        {
            List<Pergunta> perguntas = _context.Perguntas.Where(x => x.Ativo == true).ToList();
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

        public void Atualizar(Pergunta pergunta)
        {
            _context.Update(pergunta);
            _context.SaveChanges();
        }
    }
}
