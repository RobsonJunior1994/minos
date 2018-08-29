using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Minos.UnitTests
{
    public class TurmaTests : Tests
    {
        //private Mock<IProfessorRepository> professorRepositoryMock;
        //private Mock<ITurmaRepository> turmaRepositoryMock;
        //private AdminController sut;
        

        //public void CriaMock()
        //{
        //    this.professorRepositoryMock = new Mock<IProfessorRepository>();
        //    this.turmaRepositoryMock = new Mock<ITurmaRepository>();
        //}


        //public void CriaAdminController()
        //{
        //    this.sut = new AdminController(professorRepositoryMock.Object, turmaRepositoryMock.Object);


        //}

        

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Salvar Turma Chamando Repository Uma Vez")]
        public void DeveriaSalvarTurmaChamandoRepositoryUmaVez()
        {
            //arrange
            CriaMock();
            
            //act
            CriaAdminController();
            sut.CadastrarTurma(Grau.Medio, Serie.Primeiro, Turno.Manha, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Once);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se Serie Eh Nenhuma")]
        public void DeveriaNaoSalvarTurmaSeSerieEhVazio()
        {
            //arrange
            CriaMock();

            //act
            CriaAdminController();
            sut.CadastrarTurma(Grau.Medio, Serie.Nenhuma, Turno.Manha, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }
        
        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se Grau Eh Nenhum")]
        public void DeveriaNaoSalvarTurmaSeGrauEhNenhum()
        {
            //arrange
            CriaMock();
            
            //act
            CriaAdminController();
            sut.CadastrarTurma(Grau.Nenhum, Serie.Nono, Turno.Manha, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se Turno Eh Nenhum")]
        public void DeveriaNaoSalvarTurmaSeTurnoEhNenhum()
        {
            //arrange
            CriaMock();
            
            //act
            CriaAdminController();
            sut.CadastrarTurma(Grau.Medio, Serie.Nono, Turno.Nenhum, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Salvar Turma Se CodigoTurma Eh Valido")]
        public void DeveriaSalvarTurmaSeCodigoTurmaEhValido()
        {
            //arrange
            CriaMock();
            
            //act
            CriaAdminController();
            sut.CadastrarTurma(Grau.Medio, Serie.Primeiro, Turno.Manha, "A1T");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Once);

        }

        [Trait("TurmaController", "Salvar Turma")]
        [Fact(DisplayName = "Deveria Não Salvar Turma Se CodigoTurma Nao Eh Valido")]
        public void DeveriaNaoSalvarTurmaSeCodigoTurmaNaoEhValido()
        {
            //arrange
            CriaMock();
            
            //act
            CriaAdminController();
            sut.CadastrarTurma(Grau.Medio, Serie.Nono, Turno.Manha, "****");


            //assert
            turmaRepositoryMock.Verify(x => x.Salvar(It.IsAny<Turma>()), Times.Never);

        }

        [Trait("TurmaController", "Gerar CodigoTurma")]
        [Fact(DisplayName = "Deveria Gerar CodigoTurma Corretamente Quando CodigoTurma For Nulo")]
        public void DeveriaGerarCodigoTurmaCorretamenteQuandoCodigoTurmaForNulo()
        {
            var turma1 = new Turma(Grau.Fundamental, Serie.Nono, Turno.Manha, null);
            var turma2 = new Turma(Grau.Medio, Serie.Segundo, Turno.Tarde, null);
            var turma3 = new Turma(Grau.Medio, Serie.Primeiro, Turno.Noite, null);

            string codigoFinal1 = "01EF9M";
            string codigoFinal2 = "01EM2T";
            string codigoFinal3 = "01EM1N";

            Assert.True(turma1.CodigoTurma == codigoFinal1);
            Assert.True(turma2.CodigoTurma == codigoFinal2);
            Assert.True(turma3.CodigoTurma == codigoFinal3);
        }

        [Trait("TurmaController", "Gerar CodigoTurma")]
        [Fact(DisplayName = "Deveria Nao Gerar CodigoTurma Quando CodigoTurma For Diferente Nulo")]
        public void DeveriaNaoGerarCodigoTurmaQuandoCodigoTurmaForDiferenteNulo()
        {
            var turma = new Turma(Grau.Fundamental, Serie.Nono, Turno.Manha, "BLA");
         
            string codigoFinal = "01EF9M";

            Assert.True(turma.CodigoTurma != codigoFinal && turma.CodigoTurma == "BLA");
        }
    }
}
