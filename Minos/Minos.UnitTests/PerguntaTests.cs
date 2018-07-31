using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Minos.UnitTests
{
    public class PerguntaTests : Tests
    {

        [Trait("PerguntaController", "Cadastrar Pergunta")]
        [Fact(DisplayName = "Deveria Salvar Questionario Quando Chamando O Pergunta Repository Salvar Uma Vez")]
        public void DeveriaSalvarPerguntaQuandoChamandoOPerguntaRepositorySalvarUmaVez()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();

            sut.CadastrarPergunta("Qual nota você da para a calegrafia do seu professor?");

            //assert
            perguntaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Pergunta>()), Times.Once);
        }
    }
}
