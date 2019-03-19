using Minos.Site.Controllers;
using Minos.Site.Models;
using System.Collections.Generic;

namespace Minos.Site.Models
{
    public interface IQuestionarioRepository
    {
        Questionario ObterQuestionarioPeloId(int id);
        List<Questionario> ListarQuestionarios();
        void Salvar(Questionario Questionario);
        void Atualizar(Questionario questionario);
    }
}