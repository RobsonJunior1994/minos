using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;


namespace Minos.Site.Controllers
{
    public class QuestionarioController : Controller
    {
        private IAlunoRepository _alunoRepository;
        private IRespostaRepository _respostaRepository;
        private IQuestionarioRepository _questionarioRepository;

        public QuestionarioController(
            IAlunoRepository alunoRepository,
            IRespostaRepository respostaRepository,
            IQuestionarioRepository questionarioRepository)
        {
            _alunoRepository = alunoRepository;
            _respostaRepository = respostaRepository;
            _questionarioRepository = questionarioRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var logado = HttpContext.Session.GetString("LogarAluno");
            var aluno = _alunoRepository.ObterAlunoPorMatricula(logado);

            if (logado == null ||
                logado.ToString() != logado.ToString())
            {
                return RedirectToAction("Login", "Usuario");
            }

            var questionario = _questionarioRepository.ObterQuestionarioAtivo();
            
            if (questionario == null)
            {
                TempData["ErroQuestionarioNull"] = "Por favor verifique se existe algum questionário cadastrado.";
                return RedirectToAction("Index", "Questionario");
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

        //[HttpPost]
        //public IActionResult Index()
        //{
        //    Resposta resposta = new Resposta();

        //    if (resposta.EhRespostaValida())
        //    {
        //        _respostaRepository.Salvar(resposta.Resultado());
        //    }
        //    else
        //    {

        //        return View();
        //    }
        //    return View();
        //}
    }
}