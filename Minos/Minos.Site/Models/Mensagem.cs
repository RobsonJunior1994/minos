using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Mensagem
    {
        public string CadastroQuestionarioIncorreto()
        {
            string mensagem = "Parâmetros Incorretos, por favor insira os dados necessários.";
            return mensagem;
        }

        public string QuestionarioNaoExiste()
        {
            string mensagem = "Questionario não existe";
            return mensagem;
        }

        public string CadastroPerguntaIncorreto()
        {
            string mensagem = "O cadastro de pergunta está incorreto, por favor envie os paramatros necessários!";
            return mensagem;
        }

        public string CadastroProfessorIncorreto()
        {
            string mensagem = "Envie os dados do professor de forma correta!";
            return mensagem;
        }

        public string TurmaCodigoInvalido()
        {
            string mensagem = "Por favor, preencha os campos corretamente";
            return mensagem;
        }

        public string CadastroTurmaInvalido()
        {
            string mensagem = "Por favor, preencha todos os campos necessários!";
            return mensagem;
        }

        public string CadastroTurmaValido()
        {
            string mensagem = "Turma Cadastrada!";
            return mensagem;
        }

        public string LoginInvalido()
        {
            string mensagem = "Porfavor Digite um Login Válido!";
            return mensagem;
        }

        public string SenhaInvalida()
        {
            string mensagem = "Porfavor Digite uma Senha Válida!";
            return mensagem;
        }

        public string SenhaLoginValido()
        {
            string mensagem = "Login e Senha Válidos";
            return mensagem;
        }
    }
}
