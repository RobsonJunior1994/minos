using Microsoft.AspNetCore.Mvc;
using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Minos.UnitTests
{
    public class QuestionarioTests : Tests
    {
        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Lista De Perguntas For Vazia")]
        public void DeveriaNaoSalvarQuestionarioQuandoListaDePerguntasForVazia()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            var listaDePerguntas = new List<int>();

            var periodo = new Periodo();
            periodo.DataInicial = DateTime.Now;
            periodo.DataFinal = new DateTime(2008, 5, 1, 8, 30, 52);

            sut.CadastrarQuestionario();

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }

        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Lista De Perguntas For Null")]
        public void DeveriaNaoSalvarQuestionarioQuandoListaDePerguntasForNull()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();

            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
            List<int> listaDeIdDePerguntas = null;

            var periodo = new Periodo();
            periodo.DataInicial = DateTime.Now;
            periodo.DataFinal = new DateTime(2008, 5, 1, 8, 30, 52);

            var cadastroQuestionario = new QuestionarioCadastroViewModel()
            {
                PeriodoInicial = periodo.DataInicial,
                PeriodoFinal = periodo.DataFinal,
                ListaDeIdDePerguntas = listaDeIdDePerguntas
            };

            sut.CadastrarQuestionario(cadastroQuestionario);

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }

        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Periodo Inicial Ou Final For Default")]
        public void DeveriaNaoSalvarQuestionarioQuandoPeriodoForVazia()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();

            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
            var listaDeIdDePerguntas = new List<int>();
            Pergunta pergunta = new Pergunta("Você se da bem com o seu professor?");
            listaDeIdDePerguntas.Add(1);

            var periodo = new Periodo();

            var cadastroQuestionario = new QuestionarioCadastroViewModel()
            {
                PeriodoInicial = periodo.DataInicial,
                PeriodoFinal = periodo.DataFinal,
                ListaDeIdDePerguntas = listaDeIdDePerguntas
            };

            sut.CadastrarQuestionario(cadastroQuestionario);
            
            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }


        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Salvar Questionario Uma Unica Vez Quando O Metodo Salvar For Chamado")]
        public void DeveriaSalvarQuestionarioUmaUnicaVezQuandoOMetodoSalvarForChamado()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();

            var Nome = "Questionario1";

            int n = 1;
            var listaDeIdDePerguntas = new List<int>();
            listaDeIdDePerguntas.Add(n);
            
            perguntaRepositoryMock.Setup(x => x.ObterPerguntaPeloId(n)).Returns(new Pergunta("blablablabla") {Id = 1});

            var periodo = new Periodo()
            {
                DataInicial = DateTime.Now,
                DataFinal = DateTime.Now.AddDays(4)
            };

            var cadastroQuestionario = new QuestionarioCadastroViewModel()
            {  
                NomeDoQuestionario = Nome,
                PeriodoInicial = periodo.DataInicial,
                PeriodoFinal = periodo.DataFinal,
                ListaDeIdDePerguntas = listaDeIdDePerguntas
            };

            sut.CadastrarQuestionario(cadastroQuestionario);
            

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Once);
        }

        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Data Inicial For Anterior A Hoje")]
        public void DeveriaNaoSalvarQuestionarioQuandoDataInicialForAnteriorAHoje()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            
            var listaDeIdDePerguntas = new List<int>();
            listaDeIdDePerguntas.Add(1);

            var periodo = new Periodo()
            {
                DataInicial = DateTime.Now.AddDays(-1),
                DataFinal = DateTime.Now.AddDays(4)
            };

            var cadastroQuestionario = new QuestionarioCadastroViewModel()
            {
                PeriodoInicial = periodo.DataInicial,
                PeriodoFinal = periodo.DataFinal,
                ListaDeIdDePerguntas = listaDeIdDePerguntas
            };

            sut.CadastrarQuestionario(cadastroQuestionario);

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }

        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Data Final For Anterior A DataInicial")]
        public void DeveriaNaoSalvarQuestionarioQuandoDataFinalForAnteriorADataInicial()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();

            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            var listaDePerguntas = new List<int>();
            listaDePerguntas.Add(1);

            var periodo = new Periodo()
            {
                DataInicial = DateTime.Now,
                DataFinal = DateTime.Now.AddDays(-3)
            };


            sut.CadastrarQuestionario();

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }

        [Trait("QuestionarioController", "Exibir Questionario")]
        [Fact(DisplayName = "Deveria Retornar ViewModel de QuestionarioAlunoViewModel")]
        public void DeveriaRetornarView()
        {
            //arrange
            CriaMock();

            //act
            CriaQuestionarioController();

            var turma = new Turma(Grau.Medio, Serie.PrimeiroAno, Turno.Manha, "EM1M");
            alunoRepositoryMock.Setup(x => x.ObterAlunoPorMatricula(It.IsAny<string>())).Returns(new Aluno("Eneas", "Lucas", turma));

            var listaDePerguntas = new List<QuestionarioPergunta>();
            Pergunta pergunta = new Pergunta("Voce se da bem com o seu professor?");
            listaDePerguntas.Add(new QuestionarioPergunta() { Pergunta = pergunta });

            var periodo = new Periodo() { DataInicial = DateTime.Now, DataFinal = DateTime.Now };

            var questionario = new Questionario(listaDePerguntas, periodo);

            turma.Questionarios = new List<Questionario>();
            turma.Questionarios.Add(questionario);

            IActionResult result = sut2.Index();


            //assert
            Object.Equals(result, typeof(ViewResult));
        }

        [Trait("QuestionarioController", "Exibir Questionario")]
        [Fact(DisplayName = "Deveria Retornar Mensagem De Erro Se Questionario Eh Null")]
        public void DeveriaRetornarMensagemDeErroSeQuestionarioEhNull()
        {
            //arrange
            CriaMock();

            //act
            CriaQuestionarioController();

            var turma = new Turma(Grau.Medio, Serie.PrimeiroAno, Turno.Manha, "EM1M");
            alunoRepositoryMock.Setup(x => x.ObterAlunoPorMatricula(It.IsAny<string>())).Returns(new Aluno("Eneas", "Lucas", turma));

            var listaDePerguntas = new List<QuestionarioPergunta>();
            Pergunta pergunta = new Pergunta("Voce se da bem com o seu professor?");
            listaDePerguntas.Add(new QuestionarioPergunta() { Pergunta = pergunta });

            var periodo = new Periodo() { DataInicial = DateTime.Now.AddDays(1), DataFinal = DateTime.Now };

            var questionario = new Questionario(listaDePerguntas, periodo);

            turma.Questionarios = new List<Questionario>();
            turma.Questionarios.Add(questionario);

            IActionResult result = sut2.Index();
            string mensagem = "Questionario não existe!";

            //assert
            Object.Equals(mensagem, typeof(ViewResult));
        }

        [Trait("QuestionarioController", "Listar Questionario")]
        [Fact(DisplayName = "Deveria Retornar ViewModel de QuestionarioListaViewModel")]
        public void DeveriaRetornarViewModelDeQuestionarioListaViewModel()
        {
            //arrange
            CriaMock();
            CriaAdminController();

            //act

            var perguntas = new List<QuestionarioPergunta>();
            var pergunta = new Pergunta() { Id = 1, Texto = "Voce se da bem com seu professor?" };
            var perguntaQ = new QuestionarioPergunta() { PerguntaId = 1, Pergunta = pergunta};
            perguntas.Add(perguntaQ);

            var periodo = new Periodo() { Id = 1, DataInicial = DateTime.Now, DataFinal = DateTime.Now.AddDays(3) };
            var questionarios = new List<Questionario>();
            var questionario = new Questionario() { Id = 1, Perguntas = perguntas, Periodo = periodo };
            questionarios.Add(questionario);

            questionarioRepositoryMock.Setup(x => x.ListarQuestionarios()).Returns(questionarios);


            IActionResult result = sut.ListarQuestionario();

            //assert
            Object.Equals(result, typeof(ViewResult));
        }

        [Trait("QuestionarioController", "Listar Questionario")]
        [Fact(DisplayName = "Deveria Não Retornar ViewModel de QuestionarioListaViewModel Se NomeQuestionario For Null")]
        public void DeveriaNãoRetornarViewModelDeQuestionarioListaViewModelSeNomeQuestionarioForNull()
        {
            //arrange
            CriaMock();
            CriaAdminController();

            //act
            var perguntas = new List<QuestionarioPergunta>();
            var pergunta = new Pergunta() { Id = 1, Texto = "Voce se da bem com seu professor?" };
            var perguntaQ = new QuestionarioPergunta() { PerguntaId = 1, Pergunta = pergunta };
            perguntas.Add(perguntaQ);

            var periodo = new Periodo() { Id = 1, DataInicial = DateTime.Now, DataFinal = DateTime.Now.AddDays(2) };

            var questionarios = new List<Questionario>();
            var questionario = new Questionario() { Id = 1, Nome = null, Perguntas = perguntas, Periodo = periodo };

            questionarioRepositoryMock.Setup(x => x.ListarQuestionarios()).Returns(questionarios);


            IActionResult result = sut.ListarQuestionario();
            string mensagem = "Questionario não existe!";

            //assert
            Object.Equals(mensagem, typeof(ViewResult));
        }

        [Trait("QuestionarioController", "Listar Questionario")]
        [Fact(DisplayName = "Deveria Não Retornar ViewModel de QuestionarioListaViewModel Se Questionario For Null")]
        public void DeveriaNãoRetornarViewModelDeQuestionarioListaViewModelSeQuestionarioForNull()
        {
            //arrange
            CriaMock();
            CriaAdminController();

            //act
            var nome = "NomeQuestionari";

            var perguntas = new List<QuestionarioPergunta>();
            var pergunta = new Pergunta() { Id = 1, Texto = "Voce se da bem com seu professor?" };
            var perguntaQ = new QuestionarioPergunta() { PerguntaId = 1, Pergunta = pergunta };
            perguntas.Add(perguntaQ);

            var periodo = new Periodo() { Id = 1, DataInicial = DateTime.Now, DataFinal = DateTime.Now.AddDays(2) };

            var questionarios = new List<Questionario>();
            var questionario = new Questionario() { Nome = nome, Perguntas = perguntas, Periodo = periodo };

            questionarioRepositoryMock.Setup(x => x.ListarQuestionarios()).Returns(questionarios);


            IActionResult result = sut.ListarQuestionario();
            string mensagem = "Questionario não existe!";

            //assert
            Object.Equals(mensagem, typeof(ViewResult));
        }
    }
}
