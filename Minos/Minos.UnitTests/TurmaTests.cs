using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Minos.UnitTests
{
    public class TurmaTests
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
            sut.CadastrarTurma(Serie.Nono, Grau.Medio, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Once);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se Serie Eh Nenhuma")]
        public void DeveriaNaoSalvarTurmaSeSerieEhVazio()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma(Serie.Nenhuma,Grau.Medio, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }
        
        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se Grau Eh Nenhum")]
        public void DeveriaNaoSalvarTurmaSeGrauEhNenhum()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma(Serie.Nono, Grau.Nenhum, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se CodigoTurma Eh Null")]
        public void DeveriaNaoSalvarTurmaSeCodigoTurmaEhNull()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma(Serie.Nono, Grau.Nenhum, null);


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se CodigoTurma Nao Eh Valido")]
        public void DeveriaNaoSalvarTurmaSeCodigoTurmaNaoEhValido()
        {
            //arrange
            CriaMock();
            CriaTurmaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma(Serie.Nono, Grau.Nenhum, "");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }
    }
}
