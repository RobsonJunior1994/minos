using Microsoft.AspNetCore.Mvc;
using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

//namespace Minos.UnitTests
//{
//    public class QuestionarioTests : Tests
//    {   
//        [Trait("QuestionarioController", "Cadastrar Questionario")]
//        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Lista De Perguntas For Vazia")]
//        public void DeveriaNaoSalvarQuestionarioQuandoListaDePerguntasForVazia()
//        {
//            //arrange
//            CriaMock();
//            PopulaTurmaId();

//            //act
//            CriaAdminController();
//            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma(Grau.Nenhum, Serie.Nenhuma, Turno.Nenhum, ""));
//            sut.CadastrarProfessor("Robson", "Junior", turmaId);
//            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
//            var listaDePerguntas = new List<Pergunta>();

//            var periodo = new Periodo();
//            periodo.DataInicial = DateTime.Now;
//            periodo.DataFinal = new DateTime(2008, 5, 1, 8, 30, 52);

//            sut.CadastrarQuestionario(listaDePerguntas, periodo);

//            //assert
//            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
//        }

//        [Trait("QuestionarioController", "Cadastrar Questionario")]
//        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Lista De Perguntas For Null")]
//        public void DeveriaNaoSalvarQuestionarioQuandoListaDePerguntasForNull()
//        {
//            //arrange
//            CriaMock();
//            PopulaTurmaId();

//            //act
//            CriaAdminController();
            
//            sut.CadastrarProfessor("Robson", "Junior", turmaId);
//            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
//            List<Pergunta> listaDePerguntas = null;

//            var periodo = new Periodo();
//            periodo.DataInicial = DateTime.Now;
//            periodo.DataFinal = new DateTime(2008, 5, 1, 8, 30, 52);

            sut.CadastrarQuestionario(listaDePerguntas, periodo); ;

//            //assert
//            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
//        }

//        [Trait("QuestionarioController", "Cadastrar Questionario")]
//        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Periodo For null")]
//        public void DeveriaNaoSalvarQuestionarioQuandoPeriodoForNull()
//        {
//            //arrange
//            CriaMock();
//            PopulaTurmaId();

//            //act
//            CriaAdminController();
            
//            sut.CadastrarProfessor("Robson", "Junior", turmaId);
//            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
//            var listaDePerguntas = new List<Pergunta>();
//            Pergunta pergunta = new Pergunta("Você se da bem com o seu professor?");
//            listaDePerguntas.Add(pergunta);

//            Periodo periodo = null;

//            sut.CadastrarQuestionario(listaDePerguntas, periodo);

//            //assert
//            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
//        }


//        [Trait("QuestionarioController", "Cadastrar Questionario")]
//        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Periodo For Vazia")]
//        public void DeveriaNaoSalvarQuestionarioQuandoPeriodoForVazia()
//        {
//            //arrange
//            CriaMock();
//            PopulaTurmaId();

//            //act
//            CriaAdminController();
            
//            sut.CadastrarProfessor("Robson", "Junior", turmaId);
//            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
//            var listaDePerguntas = new List<Pergunta>();
//            Pergunta pergunta = new Pergunta("Você se da bem com o seu professor?");
//            listaDePerguntas.Add(pergunta);

//            var periodo = new Periodo();

//            sut.CadastrarQuestionario(listaDePerguntas, periodo);

//            //assert
//            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
//        }


//        [Trait("QuestionarioController", "Cadastrar Questionario")]
//        [Fact(DisplayName = "Deveria Salvar Questionario Uma Unica Vez Quando O Metodo Salvar For Chamado")]
//        public void DeveriaSalvarQuestionarioUmaUnicaVezQuandoOMetodoSalvarForChamado()
//        {
//            //arrange
//            CriaMock();
//            PopulaTurmaId();

//            //act
//            CriaAdminController();
            
//            sut.CadastrarProfessor("Robson", "Junior", turmaId);
//            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
//            var listaDePerguntas = new List<Pergunta>();
//            Pergunta pergunta = new Pergunta("Você se da bem com o seu professor?");
//            listaDePerguntas.Add(pergunta);

//            var periodo = new Periodo();
//            periodo.DataInicial = DateTime.Now;
//            periodo.DataFinal = new DateTime(2019, 8, 16, 8, 30, 52);

//            sut.CadastrarQuestionario(listaDePerguntas, periodo);

//            //assert
//            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Once);
//        }

//        [Trait("QuestionarioController", "Cadastrar Questionario")]
//        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Data Inicial For Anterior A Hoje")]
//        public void DeveriaNaoSalvarQuestionarioQuandoDataInicialForAnteriorAHoje()
//        {
//            //arrange
//            CriaMock();
//            PopulaTurmaId();

//            //act
//            CriaAdminController();
            
//            sut.CadastrarProfessor("Robson", "Junior", turmaId);
//            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
//            var listaDePerguntas = new List<Pergunta>();
//            Pergunta pergunta = new Pergunta("Você se da bem com o seu professor?");
//            listaDePerguntas.Add(pergunta);

//            var periodo = new Periodo()
//            {
//                DataInicial = DateTime.Now.AddDays(-1),
//                DataFinal = DateTime.Now.AddDays(4)
//            };

//            sut.CadastrarQuestionario(listaDePerguntas, periodo);

//            //assert
//            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
//        }
        
//        [Trait("QuestionarioController", "Cadastrar Questionario")]
//        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Data Final For Anterior A DataInicial")]
//        public void DeveriaNaoSalvarQuestionarioQuandoDataFinalForAnteriorADataInicial()
//        {
//            //arrange
//            CriaMock();
//            PopulaTurmaId();

//            //act
//            CriaAdminController();
            
//            sut.CadastrarProfessor("Robson", "Junior", turmaId);
//            //sut.CadastrarQuestionario(new List<Perguntas>(), new Periodo());
//            var listaDePerguntas = new List<Pergunta>();
//            Pergunta pergunta = new Pergunta("Você se da bem com o seu professor?");
//            listaDePerguntas.Add(pergunta);

//            var periodo = new Periodo()
//            {
//                DataInicial = DateTime.Now,
//                DataFinal = DateTime.Now.AddDays(-3)
//            };

//            sut.CadastrarQuestionario(listaDePerguntas, periodo);

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }

        [Trait("QuestionarioController", "Exibir Questionario")]
        [Fact(DisplayName = "Deveria Retornar View")]
        public void DeveriaRetornarView()
        {
            //arrange
            CriaMock();

            //act
            CriaQuestionarioController();

            var turma = new Turma(Grau.Medio, Serie.Primeiro, Turno.Manha, "EM1M");
            alunoRepositoryMock.Setup(x => x.ObterAlunoPorMatricula(It.IsAny<string>())).Returns(new Aluno("Eneas", "Lucas", turma));

            var listaDePerguntas = new List<Pergunta>();
            Pergunta pergunta = new Pergunta("Voce se da bem com o seu professor?");
            listaDePerguntas.Add(pergunta);

            var periodo = new Periodo() { DataInicial = DateTime.Now, DataFinal = DateTime.Now};

            var questionario = new Questionario(listaDePerguntas, periodo);
            //{
            //    ListaDePerguntas = listaDePerguntas
            //};

            turma.Questionarios = new List<Questionario>();
            turma.Questionarios.Add(questionario);

            IActionResult result = sut2.Index("1");
            

            //assert
            Object.Equals(result, typeof(ViewResult));
        }

        [Trait("QuestionarioController", "Exibir Questionario")]
        [Fact(DisplayName = "Deveria Retornar Mensagem De Erro Se Questionario Eh Null")]
        public void Deveria()
        {
            //arrange
            CriaMock();

            //act
            CriaQuestionarioController();

            var turma = new Turma(Grau.Medio, Serie.Primeiro, Turno.Manha, "EM1M");
            alunoRepositoryMock.Setup(x => x.ObterAlunoPorMatricula(It.IsAny<string>())).Returns(new Aluno("Eneas", "Lucas", turma));

            var listaDePerguntas = new List<Pergunta>();
            Pergunta pergunta = new Pergunta("Voce se da bem com o seu professor?");
            listaDePerguntas.Add(pergunta);

            var periodo = new Periodo() { DataInicial = DateTime.Now.AddDays(1), DataFinal = DateTime.Now };

            var questionario = new Questionario(listaDePerguntas, periodo);

            turma.Questionarios = new List<Questionario>();
            turma.Questionarios.Add(questionario);

            IActionResult result = sut2.Index("1");
            string mensagem = "Questionario não existe!";

            //assert
            Object.Equals(mensagem, typeof(ViewResult));
        }
    }
}
