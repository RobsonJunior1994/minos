using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Minos.UnitTests
{
    public class QuestionarioTests
    {

        private AdminController sut;
        private Mock<IProfessorRepository> professorRepositoryMock;
        private Mock<ITurmaRepository> turmaRepositoryMock;
        private Mock<IQuestinarioRepository> questionarioRepositoryMock;
        private List<int> turmaId;


        public void PopulaTurmaId()
        {
            turmaId = new List<int>();
            turmaId.Add(01);
        }

        public void CriaMock()
        {
            this.professorRepositoryMock = new Mock<IProfessorRepository>();
            this.turmaRepositoryMock = new Mock<ITurmaRepository>();
            this.questionarioRepositoryMock = new Mock<IQuestinarioRepository>();
            

    }

    public void CriaAdminController()
        {
            sut = new AdminController(professorRepositoryMock.Object, turmaRepositoryMock.Object, questionarioRepositoryMock.Object);
            
        }

        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Lista De Perguntas For Vazia")]
        public void DeveriaNaoSalvarQuestionarioQuandoListaDePerguntasForVazia()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma());
            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //sut.CadastrarQuestinario(new List<Perguntas>(), new Periodo());
            var listaDePerguntas = new List<Perguntas>();

            var periodo = new Periodo();
            periodo.DataInicial = DateTime.Now;
            periodo.DataFinal = new DateTime(2008, 5, 1, 8, 30, 52);

            sut.CadastrarQuestinario(listaDePerguntas, periodo);

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
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma());
            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //sut.CadastrarQuestinario(new List<Perguntas>(), new Periodo());
            List<Perguntas> listaDePerguntas = null;

            var periodo = new Periodo();
            periodo.DataInicial = DateTime.Now;
            periodo.DataFinal = new DateTime(2008, 5, 1, 8, 30, 52);

            sut.CadastrarQuestinario(listaDePerguntas, periodo);

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }

        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Periodo For null")]
        public void DeveriaNaoSalvarQuestionarioQuandoPeriodoForNull()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma());
            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //sut.CadastrarQuestinario(new List<Perguntas>(), new Periodo());
            var listaDePerguntas = new List<Perguntas>();
            Perguntas pergunta = new Perguntas();
            listaDePerguntas.Add(pergunta);

            Periodo periodo = null;

            sut.CadastrarQuestinario(listaDePerguntas, periodo);

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }


        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Nao Salvar Questionario Quando Periodo For Vazia")]
        public void DeveriaNaoSalvarQuestionarioQuandoPeriodoForVazia()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma());
            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //sut.CadastrarQuestinario(new List<Perguntas>(), new Periodo());
            var listaDePerguntas = new List<Perguntas>();
            Perguntas pergunta = new Perguntas();
            listaDePerguntas.Add(pergunta);

            var periodo = new Periodo();

            sut.CadastrarQuestinario(listaDePerguntas, periodo);

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }


        [Trait("QuestionarioController", "Cadastrar Questionario")]
        [Fact(DisplayName = "Deveria Salvar Questionario Quando Chamando O Questionario Repository Salvar Uma Vez")]
        public void DeveriaSalvarQuestionarioQuandoChamandoOQuestionarioRepositorySalvarUmaVez()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            turmaRepositoryMock.Setup(x => x.ObterTurmaPeloId(It.IsAny<int>())).Returns(new Turma());
            sut.CadastrarProfessor("Robson", "Junior", turmaId);
            //sut.CadastrarQuestinario(new List<Perguntas>(), new Periodo());
            var listaDePerguntas = new List<Perguntas>();
            Perguntas pergunta = new Perguntas();
            listaDePerguntas.Add(pergunta);

            var periodo = new Periodo();
            periodo.DataInicial = DateTime.Now;
            periodo.DataFinal = new DateTime(2008, 5, 1, 8, 30, 52);

            sut.CadastrarQuestinario(listaDePerguntas, periodo);

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Once);
        }


    }
}
