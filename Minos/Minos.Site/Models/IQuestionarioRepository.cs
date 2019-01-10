using Minos.Site.Controllers;
using Minos.Site.Models;
using System.Collections.Generic;

namespace Minos.Site.Models
{
    public interface IQuestionarioRepository
    {
        Questionario ObterListaDePerguntas();
        List<Questionario> ListarQuestionarios();
        void Salvar(Questionario Questionario);
    }
}