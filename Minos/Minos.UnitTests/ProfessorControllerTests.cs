using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using Xunit;

namespace Minos.UnitTests
{
    public class ProfessorControllerTests
    {
        private Mock<IProfessorRepository> professorRepositoryMock;
        private AdminController sut;
        
        public void CriaMock()
        {
            this.professorRepositoryMock = new Mock<IProfessorRepository>();
        }

        
        public void CriaAdminController()
        {
            this.sut = new AdminController(professorRepositoryMock.Object);
        }

        [Trait("ProfessorController", "Salvar Professor")]
        [Fact(DisplayName = "Deveria Salvar Professor Chamando Repository Uma Vez")]
        public void DeveriaSalvarProfessorChamandoRepositoryUmaVez()
        {
            //arrange
            CriaMock();

            //act
            CriaAdminController();
            sut.CadastrarProfessor("Robson", "Junior","Serie",Grau.Fundamental);

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Once);
        }

        

        [Trait("ProfessorController", "Deveria não salvar professor com numero")]
        [Fact(DisplayName = "Deveria não salvar professor com numero")]
        public void DeveriaNaoSalvarProfessorComNumero()
        {
            //arrange
            CriaMock();

            //act
            CriaAdminController();

            sut.CadastrarProfessor("Robso2n", "Robson", "Serie", Grau.Fundamental);
            

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);
        }

        [Trait("ProfessorController", "Deveria não salvar professor com null")]
        [Fact(DisplayName = "Deveria não salvar professor com null")]
        public void DeveriaNaoSalvarProfessorComNull()
        {
            //arrange
            CriaMock();
            //act
            CriaAdminController();
            sut.CadastrarProfessor("Robson", null, "Serie", Grau.Fundamental);
            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }

        [Trait("ProfessorController", "Deveria não salvar professor com Vazio")]
        [Fact(DisplayName = "Deveria não salvar professor com Vazio")]
        public void DeveriaNaoSalvarProfessorComVazio()
        {
            //arrange
            CriaMock();
            //act
            CriaAdminController();
            sut.CadastrarProfessor("", "Junior", "Serie", Grau.Fundamental);
            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }

        [Trait("ProfessorController", "Deveria não salvar professor sem Serie")]
        [Fact(DisplayName = "Deveria não salvar professor sem Serie")]
        public void DeveriaNaoSalvarProfessorSemSerie()
        {
            //arrange
            CriaMock();
            //act
            CriaAdminController();
            sut.CadastrarProfessor("", "Junior", "Serie", Grau.Fundamental);
            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }
    }
}
