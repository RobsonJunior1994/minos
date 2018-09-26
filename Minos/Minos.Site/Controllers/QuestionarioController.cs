using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;


namespace Minos.Site.Controllers
{
    public class QuestionarioController : Controller
    {
        private IAlunoRepository _alunoRepository;

        public IActionResult Index(string matriculaDoAluno)
        {
            var aluno = _alunoRepository.ObterAlunoPorMatricula(matriculaDoAluno);

            var questionario =
                aluno
                .Turma
                .Questionarios
                .FirstOrDefault(x =>
                    x.Periodo.DataInicial >= DateTime.Now &&
                    x.Periodo.DataFinal <= DateTime.Now);

            if (questionario == null) { }
            //retorna mensagem de erro
            ViewData["Message"] = "Questinário não existe.";

            var viewModel = new QuestionarioAlunoViewModel()
            {
                CodigoDaTurma = aluno.Turma.CodigoTurma,
                Matricula = aluno.Matricula,
                NomeDoAluno = aluno.Nome + " " + aluno.Sobrenome
            };

            foreach (var perguntaClasse in questionario.ListaDePerguntas)
                viewModel.Perguntas.Add(perguntaClasse.pergunta);

            foreach (var professor in aluno.Turma.Professores)
                viewModel.Professores.Add(professor.Nome + " " + professor.Sobrenome);

            return View(viewModel);
        }
    }
}