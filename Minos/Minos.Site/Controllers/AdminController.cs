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
        private IPeriodoRepository _periodoRepository;

        public AdminController(
            IProfessorRepository professorRepository,
            ITurmaRepository turmaRepository,
            IQuestionarioRepository questionarioRepository,
            IPerguntaRepository perguntaRepository,
            IPeriodoRepository periodoRepository)
        {
            _professorRepository = professorRepository;
            _turmaRepository = turmaRepository;
            _questionarioRepository = questionarioRepository;
            _perguntaRepository = perguntaRepository;
            _periodoRepository = periodoRepository;
            
        }

        public IActionResult Index()
        {
            var logado = HttpContext.Session.GetString("LogarAdm");

            if (logado == null || logado.ToString() != logado.ToString())
            {
                return RedirectToAction("Login", "Usuario");
            }
            
            return View();
            
        }
        
        [HttpGet]
        public IActionResult CadastrarTurma()
        {
            var grau = new Grau();
            ViewData["Grau"] = grau;
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
            ViewBag.turmas = _turmaRepository.ListarTurmas();
            ViewBag.professores = _professorRepository.ListarProfessores();
            return View();
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

                var professorturma = new ProfessorTurma();

                professorturma.ProfessorId = professor.Id;
                professorturma.TurmaId = turma.Id;

                professor.Turmas.Add(professorturma);
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

            return RedirectToAction("cadastrarprofessor", "Admin");
        }

        [HttpGet]
        public IActionResult CadastrarQuestionario()
        {
            ViewBag.periodos = _periodoRepository.ListarPeriodos();
            ViewBag.perguntas = _perguntaRepository.ListarPergunras();
            return View();
        }


        [HttpPost]
        public IActionResult CadastrarQuestionario(List<int> listaDeIdDePerguntas, DateTime periodoInicial, DateTime periodoFinal)
        {

            //Periodo periodo = _periodoRepository.ObterPeriodoPeloId(periodoId);
            Periodo periodo = new Periodo();
            periodo.DataInicial = periodoInicial;
            periodo.DataFinal = periodoFinal;

            Questionario questionario = new Questionario(periodo);
            if(listaDeIdDePerguntas == null || listaDeIdDePerguntas.Count() == 0)
            {
                return View();
            }

            foreach (var perguntaId in listaDeIdDePerguntas)
            {
                Pergunta pergunta = new Pergunta();
                pergunta = _perguntaRepository.ObterPerguntaPeloId(perguntaId);
                if (pergunta == null || pergunta.Id == 0) return View();

                var questionarioPergunta = new QuestionarioPergunta();
                questionarioPergunta.PerguntaId = pergunta.Id;
                questionarioPergunta.QuestionarioId = questionario.Id;

                questionario.Perguntas.Add(questionarioPergunta);
            }
            
            if (questionario.EhValido())
            {
                _questionarioRepository.Salvar(questionario);
            }
            else
            {
                ViewData["Message"] = "O cadastro de questionario está incorreto, por favor envie os paramatros necessários!";
            }

            return RedirectToAction("CadastrarQuestionario", "Admin");
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

        [HttpGet]
        public IActionResult CadastrarPeriodo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarPeriodo(DateTime inicial, DateTime final)
        {
            return View();
        }
    }
}
