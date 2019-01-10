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

        public Questionario ObterListaDePerguntas()
        {
            throw new NotImplementedException();
        }

        public void Salvar(Questionario Questionario)
        {
            _context.Add(Questionario);
            _context.SaveChanges();
        }
    }
}
