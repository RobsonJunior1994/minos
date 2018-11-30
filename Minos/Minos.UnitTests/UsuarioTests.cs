using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Minos.UnitTests
{
    public class UsuarioTests : Tests
    {
        //TESTES
        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Salvar Usuario Chamando Repository Uma Vez")]
        public void DeveriaSalvarUsuarioChamandoRepositoryUmaVez()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("Robson", "Senha1");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Once);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Login Eh Vazio")]
        public void DeveriaNaoSalvarUsuarioSeLoginEhVazio()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("", "Senha1");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Login Eh Null")]
        public void DeveriaNaoSalvarUsuarioSeLoginEhNull()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario(null, "Senha1");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Login Eh Menor Que Cinco")]
        public void DeveriaNaoSalvarUsuarioSeLoginEhMenorQueCinco()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("Enea", "Senha1");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Login Eh Maior Que Vinte")]
        public void DeveriaNaoSalvarUsuarioSeLoginEhMaiorQueVinte()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("EneasLucasPaulaMarti", "Senha1");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Senha Eh Vazia")]
        public void DeveriaNaoSalvarUsuarioSeSenhaEhVazia()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("Robson", "");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Senha Eh Null")]
        public void DeveriaNaoSalvarUsuarioSeSenhaEhNull()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("Robson", null);


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Senha Eh Menor Que Seis")]
        public void DeveriaNaoSalvarUsuarioSeSenhaEhMenorQueSeis()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("Eneas", "Senha");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }

        [Trait("UsuarioController", "Cadastrar Usuario")]
        [Fact(DisplayName = "Deveria Nao Salvar Usuario Se Senha Eh Maior Que Quinze")]
        public void DeveriaNaoSalvarUsuarioSeSenhaEhMaiorQueQuinze()
        {
            //arrange
            CriaMock();

            //act
            CriaUsuarioController();
            sut3.CadastrarUsuario("Eneas", "Senha0123456789");


            //assert
            usuarioRepositoryMock.Verify(x => x.Salvar(It.IsAny<Usuario>()), Times.Never);
        }
    }
}
