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
            sut.CadastrarQuestinario(new List<Perguntas>(), new Periodo());

            //assert
            questionarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Questionario>()), Times.Never);
        }
    }
}
