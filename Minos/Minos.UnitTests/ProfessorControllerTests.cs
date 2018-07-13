using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using Xunit;

namespace Minos.UnitTests
{
    public class ProfessorControllerTests
    {
        [Trait("ProfessorController", "Salvar Professor")]
        [Fact(DisplayName = "Deveria Salvar Professor ChamandoRepository Uma Vez")]
        public void DeveriaSalvarProfessorChamandoRepositoryUmaVez()
        {
            //arrange
            Mock<IProfessorRepository> professorRepositoryMock = new Mock<IProfessorRepository>();

            //act
            var sut = new AdminController(professorRepositoryMock.Object);
            sut.CadastrarProfessor("Robson", "Junior");

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Once);
        }

        [Trait("ProfessorController", "Não Deveria salvar Professor")]
        [Fact(DisplayName = "Deveria bloquear o salvamento do Professor")]
        public void DeveriaBloquearOSalvamentoDoProfessor()
        {
            //arrange
            Mock<IProfessorRepository> professorRepositoryMock = new Mock<IProfessorRepository>();

            //act
            var sut = new AdminController(professorRepositoryMock.Object);

            sut.CadastrarProfessor("Robso2n", "Robson");
            

            //assert
            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Never);
        }
    }
}
