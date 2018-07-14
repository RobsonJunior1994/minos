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
            sut.CadastrarProfessor("Robson", "Junior", "Serie", Grau.Fundamental);

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Once);
        }

        

        [Trait("ProfessorController", "Deveria Não Salvar Nome Do Professor Com Numeros")]
        [Fact(DisplayName = "Deveria Não Salvar Nome Do Professor Com Numeros")]
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

        [Trait("ProfessorController", "Deveria Não Salvar Com Nome Do Professor Null")]
        [Fact(DisplayName = "Deveria Não Salvar Com Nome Do Professor Null")]
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

        [Trait("ProfessorController", "Deveria Não Salvar Com Nome Do Professor Vazio")]
        [Fact(DisplayName = "Deveria Não Salvar Com Nome Do Professor Vazio")]
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

        [Trait("ProfessorController", "Deveria Não Salvar Professor Com Serie Vazio")]
        [Fact(DisplayName = "Deveria Não Salvar Professor Com Serie Vazio")]
        public void DeveriaNaoSalvarProfessorSerieVazia()
        {
            //arrange
            CriaMock();
            //act
            CriaAdminController();
            sut.CadastrarProfessor("Robson", "Junior", "", Grau.Fundamental);
            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }
        [Trait("ProfessorController", "Deveria Não Salvar Professor Com Serie Null")]
        [Fact(DisplayName = "Deveria Não Salvar Professor Com Serie Null")]
        public void DeveriaNaoSalvarProfessorComSerieNula()

        {
            //arrange
            CriaMock();
            //act
            CriaAdminController();
            sut.CadastrarProfessor("Robson", "Junior", null, Grau.Fundamental);
            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }
        [Trait("ProfessorController", "Deveria Não Salvar Professor Com Grau Nenhum")]
        [Fact(DisplayName = "Deveria Não Salvar Professor Com Grau Nenhum")]
        public void DeveriaNaoSalvarProfessorComGrauNenhum()

        {
            //arrange
            CriaMock();
            //act
            CriaAdminController();
            sut.CadastrarProfessor("Robson", "Junior", "Serie", Grau.Nenhum);
            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);

        }
    }
}
