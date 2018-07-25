using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Minos.UnitTests
{
    public class TurmaControllerTests
    {
        private Mock<IProfessorRepository> professorRepositoryMock;
        private Mock<ITurmaRepository> turmaRepositoryMock;
        private AdminController sut;
        private Mock<Turma> turmaMock;
        public List<int> turmaId;
        private Turma turmaVazia;

        public void PopulaTurmaId()
        {
            turmaId = new List<int>();
            turmaId.Add(1);
        }

        public void CriaMock()
        {
            this.professorRepositoryMock = new Mock<IProfessorRepository>();
            this.turmaRepositoryMock = new Mock<ITurmaRepository>();
        }


        public void CriaAdminController()
        {
            this.sut = new AdminController(professorRepositoryMock.Object, turmaRepositoryMock.Object);


        }

        public void CriaTurmaMock()
        {
            this.turmaMock = new Mock<Turma>();
        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Salvar Turma Chamando Repository Uma Vez")]
        public void DeveriaSalvarTurmaChamandoRepositoryUmaVez()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma("1ano", Grau.Medio);


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Once);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se Serie Eh Vazio")]
        public void DeveriaSalvarTurmaSeSerieEhVazio()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma("", Grau.Medio);


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se Serie Eh Null")]
        public void DeveriaSalvarTurmaSeSerieEhNull()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma(null, Grau.Medio);


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Grau Se Eh Nenhum")]
        public void DeveriaSalvarTurmaSeGrauEhNenhum()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma("1ano", Grau.Nenhum);


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }
    }
}
