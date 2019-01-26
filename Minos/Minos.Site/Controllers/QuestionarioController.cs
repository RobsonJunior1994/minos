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
        private IRespostaRepository _respostaRepository;

        public QuestionarioController(
            IAlunoRepository alunoRepository,
            IRespostaRepository respostaRepository)
        {
            _alunoRepository = alunoRepository;
            _respostaRepository = respostaRepository;
        }
        
        [HttpGet]
        public IActionResult Index(string matriculaDoAluno)
        {
            var aluno = _alunoRepository.ObterAlunoPorMatricula(matriculaDoAluno);

            var questionario =
                aluno
                .Turma
                .Questionarios
                .FirstOrDefault(x => x.Periodo.DataInicial.Date <= DateTime.Now.Date && x.Periodo.DataFinal.Date >= DateTime.Now.Date);
           
            if (questionario == null)
            {
                TempData["ErroQuestionarioNull"] = "Por favor verifique se existe algum questionário cadastrado.";
                return RedirectToAction("Index", "Aluno");
            }

            var viewModel = new QuestionarioAlunoViewModel()
            {
                CodigoDaTurma = aluno.Turma.CodigoTurma,
                Matricula = aluno.Matricula,
                NomeDoAluno = aluno.Nome + " " + aluno.Sobrenome,
                Perguntas = new List<string>(),
                Professores = new List<string>()
            };

            foreach (var perguntaClasse in questionario.Perguntas)
                viewModel.Perguntas.Add(perguntaClasse.Pergunta.Texto);

            foreach (var professorTurma in aluno.Turma.Professores)
                viewModel.Professores.Add(professorTurma.Professor.Nome + " " + professorTurma.Professor.Sobrenome);
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index()
        {
            Resposta resposta = new Resposta();

            if (resposta.EhRespostaValida())
            {
                _respostaRepository.Salvar(resposta.Resultado());
            }
            else
            {

                return View();
            }
            return View();
        }
    }
}