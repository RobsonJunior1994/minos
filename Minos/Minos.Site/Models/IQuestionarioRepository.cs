using Minos.Site.Models;

namespace Minos.Site.Models
{
    public interface IQuestionarioRepository
    {
        Questionario ObterResposta(int _resposta);
        void Salvar(Questionario Questionario);
    }
}