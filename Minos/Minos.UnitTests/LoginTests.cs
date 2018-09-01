using Minos.Site.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Minos.UnitTests
{
    public class LoginTests : Tests
    {
        [Trait("LoginController", "Fazer Login")]
        [Fact(DisplayName = "Deveria fazer login com Sucesso")]
        public void DeveriaFazerLoginComSucesso()
        {
            //arrange
            CriaMock();

            //action
            CriaLoginController();
            sutLogin.Logar("robsonjunior1994","1234567890");

            //assert
            loginRepositoryMock.Verify(x => x.Entrar(It.IsAny<Usuario>()), Times.Once);
        }

        [Trait("LoginController", "Fazer Login")]
        [Fact(DisplayName = "Deveria não fazer login com nome de usuario vazio")]
        public void DeveriaNaoFazerLoginComNomeDeUsuarioVazio()
        {
            //arrange
            CriaMock();

            //action
            CriaLoginController();
            sutLogin.Logar("", "1234567890");

            //assert
            loginRepositoryMock.Verify(x => x.Entrar(It.IsAny<Usuario>()), Times.Never);
        }
    }
}
