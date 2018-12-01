using Minos.Site.Controllers;
using Minos.Site.Models;
using System.Collections.Generic;

namespace Minos.Site.Models
{
    public interface IQuestionarioRepository
    {
        Questionario ObterListaDePerguntas();
        void Salvar(Questionario Questionario);
    }
}