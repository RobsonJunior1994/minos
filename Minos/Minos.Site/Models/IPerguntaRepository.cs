using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public interface IPerguntaRepository
    {
        void Salvar(Pergunta pergunta);
        Pergunta ObterPerguntaPeloId(int id);
        List<Pergunta> ListarPerguntas();
        void Deletar(int id);
    }
}
