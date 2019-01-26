using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Minos.Site.Controllers;
using Minos.Site.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Minos.UnitTests
{
    public class Tests
    {
        internal AdminController sut;
        internal QuestionarioController sut2;
        internal UsuarioController sut3;
        internal Mock<IUsuarioRepository> usuarioRepositoryMock;
        internal Mock<IProfessorRepository> professorRepositoryMock;
        internal Mock<ITurmaRepository> turmaRepositoryMock;
        internal Mock<IQuestionarioRepository> questionarioRepositoryMock;
        internal Mock<IPerguntaRepository> perguntaRepositoryMock;
        internal Mock<IAlunoRepository> alunoRepositoryMock;
        internal Mock<IRespostaRepository> respostaRepositoryMock;
        internal Mock<ILoginRepository> loginRepositoryMock;
        internal Mock<IPeriodoRepository> periodoRepositoryMock;
        internal Mock<ITempDataDictionary> tempDataMock;

        internal List<int> turmaIdVazia = new List<int>();
        internal List<int> turmaId;
        internal Turma turmaNull;


        public void PopulaTurmaId()
        {
            turmaId = new List<int>();
            turmaId.Add(01);
        }

        public void CriaMock()
        {
            this.usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            this.professorRepositoryMock = new Mock<IProfessorRepository>();
            this.turmaRepositoryMock = new Mock<ITurmaRepository>();
            this.questionarioRepositoryMock = new Mock<IQuestionarioRepository>();
            this.perguntaRepositoryMock = new Mock<IPerguntaRepository>();
            this.alunoRepositoryMock = new Mock<IAlunoRepository>();
            this.respostaRepositoryMock = new Mock<IRespostaRepository>();
            this.loginRepositoryMock = new Mock<ILoginRepository>();
            this.periodoRepositoryMock = new Mock<IPeriodoRepository>();
            this.tempDataMock = new Mock<ITempDataDictionary>();
        }

        public void CriaAdminController()
        {
            sut = new AdminController(professorRepositoryMock.Object, turmaRepositoryMock.Object, questionarioRepositoryMock.Object, perguntaRepositoryMock.Object, periodoRepositoryMock.Object)
            {
                TempData = tempDataMock.Object,
            };
        }

        public void CriaQuestionarioController()
        {
            sut2 = new QuestionarioController(alunoRepositoryMock.Object, respostaRepositoryMock.Object);
        }

        public void CriaUsuarioController()
        {
            sut3 = new UsuarioController(usuarioRepositoryMock.Object, alunoRepositoryMock.Object);
        }
    }
}
