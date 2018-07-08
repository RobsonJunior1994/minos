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
        [Fact(DisplayName = "Blable")]
        public void DeveriaSalvarProfessorChamandoRepositoryUmaVez()
        {
            Mock<IProfessorRepository> professorRepositoryMock = new Mock<IProfessorRepository>();

            AdminController adminController = new AdminController(professorRepositoryMock.Object);

            adminController.CadastrarProfessor("Bla", "Ble");

            professorRepositoryMock.Verify(x => x.Salvar(It.IsAny<Professor>()), Times.Once);
        }
    }
}
