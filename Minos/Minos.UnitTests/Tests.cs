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
        internal Mock<IProfessorRepository> professorRepositoryMock;
        internal List<int> turmaIdVazia = new List<int>();
        internal Mock<ITurmaRepository> turmaRepositoryMock;
        internal Mock<IQuestionarioRepository> questionarioRepositoryMock;
        internal Mock<IPerguntaRepository> perguntaRepositoryMock;
        internal Mock<ILoginRepository> loginRepositoryMock;
        internal List<int> turmaId;
        internal Turma turmaNull;


        public void PopulaTurmaId()
        {
            turmaId = new List<int>();
            turmaId.Add(01);
        }

        public void CriaMock()
        {
            this.professorRepositoryMock = new Mock<IProfessorRepository>();
            this.turmaRepositoryMock = new Mock<ITurmaRepository>();
            this.questionarioRepositoryMock = new Mock<IQuestionarioRepository>();
            this.perguntaRepositoryMock = new Mock<IPerguntaRepository>();
            this.loginRepositoryMock = new Mock<ILoginRepository>();

        }

        public void CriaAdminController()
        {
            sut = new AdminController(professorRepositoryMock.Object, turmaRepositoryMock.Object, questionarioRepositoryMock.Object, perguntaRepositoryMock.Object);

        }
    }
}
