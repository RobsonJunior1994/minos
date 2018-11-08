using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Mensagem
    {
        string mensagem;
        public string CadastroQuestionarioIncorreto()
        {
            mensagem = "Parâmetros Incorretos, por favor insira os dados necessários.";
            return mensagem;
        }

        public string QuestionarioNaoExiste()
        {
            mensagem = "Questionario não existe";
            return mensagem;
        }
        
        public string RespostaIncorreta()
        {
            mensagem = "Por favor responda todas as perguntas.";
            return mensagem;
        }

        public string CadastroPerguntaIncorreto()
        {
            mensagem = "O cadastro de pergunta está incorreto, por favor envie os paramatros necessários!";
            return mensagem;
        }

        public string CadastroProfessorIncorreto()
        {
            mensagem = "Envie os dados do professor de forma correta!";
            return mensagem;
        }

        public string TurmaCodigoInvalido()
        {
            mensagem = "Por favor, preencha os campos corretamente";
            return mensagem;
        }

        public string CadastroTurmaInvalido()
        {
            mensagem = "Por favor, preencha todos os campos necessários!";
            return mensagem;
        }

        public string CadastroTurmaValido()
        {
            mensagem = "Turma Cadastrada!";
            return mensagem;
        }

        public string LoginInvalido()
        {
            mensagem = "Porfavor Digite um Login Válido!";
            return mensagem;
        }

        public string SenhaInvalida()
        {
            mensagem = "Porfavor Digite uma Senha Válida!";
            return mensagem;
        }

        public string SenhaLoginValido()
        {
            mensagem = "Login e Senha Válidos";
            return mensagem;
        }
    }
}
