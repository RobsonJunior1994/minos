using Microsoft.EntityFrameworkCore;
using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        private MinosContext _context;

        public QuestionarioRepository(MinosContext contexto)
        {
            _context = contexto;
        }
    
        public List<Questionario> ListarQuestionarios()
        {
            var questionarios = _context.Questionarios.ToList();
            return questionarios;
        }

        public Questionario ObterQuestionarioPeloId(int id)
        {
            var questionario = _context.Questionarios
                .Include(x => x.Perguntas).FirstOrDefault(p => p.Id == id);
            return questionario;
        }
        
        public Questionario ObterListaDePerguntas(int id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Questionario Questionario)
        {
            _context.Add(Questionario);
            _context.SaveChanges();
        }

        public void Atualizar(Questionario questionario)
        {
            _context.Questionarios.Update(questionario);
            _context.SaveChanges();

        }
    }
}
