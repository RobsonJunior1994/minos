using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace Minos.Site.Controllers
{
    public class AdminController : Controller
    {
        private IProfessorRepository _professorRepository;
        private ITurmaRepository _turmaRepository;
        private IQuestionarioRepository _questionarioRepository;
        private IPerguntaRepository _perguntaRepository;

        public AdminController(
            IProfessorRepository professorRepository,
            ITurmaRepository turmaRepository,
            IQuestionarioRepository questionarioRepository,
            IPerguntaRepository perguntaRepository)
        {
            _professorRepository = professorRepository;
            _turmaRepository = turmaRepository;
            _questionarioRepository = questionarioRepository;
            _perguntaRepository = perguntaRepository;
            
        }

        public IActionResult Index()
        {
            var logado = ViewBag.Message = HttpContext.Session.GetString("Test");
            if (logado == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            
            return View();
            
        }
        
        [HttpGet]
        public IActionResult CadastrarTurma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarTurma(Grau grau, Serie serie, Turno turno, string codigoTurma)
        {
            Turma turma = new Turma(grau, serie, turno, codigoTurma);

            if (!turma.EhCodigoValido())
            {
                ViewData["Message"] = "Por favor, preencha os campos corretamente";
                return View();
            }

            if (!turma.EhValida())
            {  
                ViewData["Message"] = "Por favor, preencha todos os campos necessários!";
                return View();
            }
            else
            {
                _turmaRepository.Salvar(turma);
            }
            return View();

        }

       
        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            List<Turma> turmas = _turmaRepository.ObterTurmasDesteAno();

            return View(turmas);
        }
        
        [HttpPost]
        public IActionResult CadastrarProfessor(string nome, string sobrenome, List<int> listaDeIdDasTurmas)
        {

            Professor professor = new Professor(nome, sobrenome);
            if (listaDeIdDasTurmas == null || listaDeIdDasTurmas.Count() == 0)
                return View();

            foreach (var turmaId in listaDeIdDasTurmas)
            {
                Turma turma = _turmaRepository.ObterTurmaPeloId(turmaId);

                if (turma == null || turma.Id == 0)
                    return View();

                professor.Turmas.Add(turma);
            }

            if (!professor.ValidaProfessor())
            {
                ViewData["Message"] = "Envie os dados do professor de forma correta!";
                return View();
            }
            else
            {
                _professorRepository.Salvar(professor);
            }
                  
            return View();
        }

        [HttpGet]
        public IActionResult CadastrarQuestionario()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CadastrarQuestionario(List<Pergunta> listaDePerguntas, Periodo periodo)
        {
            Questionario questionario = new Questionario(listaDePerguntas, periodo);
            if (questionario.EhValido())
            {
                _questionarioRepository.Salvar(questionario);
            }
            else
            {
                ViewData["Message"] = "O cadastro de questionario está incorreto, por favor envie os paramatros necessários!";
            }

            return View();
        }

        [HttpGet]
        public IActionResult CadastrarPergunta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarPergunta(string perguntaEnviada)
        {
            Pergunta pergunta = new Pergunta(perguntaEnviada);

            if (pergunta.EhValida())
            {
                _perguntaRepository.Salvar(pergunta);
            }
            else
            {
                ViewData["Message"] = "O cadastro de pergunta está incorreto, por favor envie os paramatros necessários!";
            }

            return View();
        }
    }
}
