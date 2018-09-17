using Minos.Site.Controllers;
using Minos.Site.Models;

namespace Minos.Site.Models
{
    public interface IQuestionarioRepository
    {
        void Salvar(Questionario Questionario);
    }
}