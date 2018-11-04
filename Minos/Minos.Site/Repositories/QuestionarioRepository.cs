using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class QuestionarioRepository : IQuestionarioRepository
    {
        public void Salvar(Questionario Questionario)
        {
            using (var contexto = new MinosContext())
            {
                contexto.Add(Questionario);
                contexto.SaveChanges();
            }
        }
    }
}
