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
        [Fact(DisplayName = "Deveria Salvar Pergunta Uma Vez Quando For Chamado O Metodo Salvar")]
        public void DeveriaSalvarPerguntaUmaVezQuandoForChamadoOMetodoSalvar()
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

        [Trait("PerguntaController", "Cadastrar Pergunta")]
        [Fact(DisplayName = "Deveria Não Salvar Quando pergunta for nula")]
        public void DeveriaNaoSalvarQuandoPerguntaForNull()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            string nula = null;
            sut.CadastrarPergunta(nula);

            //assert
            perguntaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Pergunta>()), Times.Never);
        }

        [Trait("PerguntaController", "Cadastrar Pergunta")]
        [Fact(DisplayName = "Deveria Nao Salvar Pergunta Quando Contiver Menos De 10 Caracter")]
        public void DeveriaNaoSalvarPerguntaQuandoContiverMenosDe10Caracter()
        {
            //arrange
            CriaMock();
            PopulaTurmaId();

            //act
            CriaAdminController();
            sut.CadastrarPergunta("Qual nota");

            //assert
            perguntaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Pergunta>()), Times.Never);
        }
    }
}
