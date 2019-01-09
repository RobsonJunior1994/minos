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
        public IActionResult ListaDeTurmas()
        {
            ViewBag.Turmas = _turmaRepository.ListarTurmas();
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
            var mensagem = new Mensagem();

            if (!turma.EhCodigoValido())
            {
                return View();
            }

            if (!turma.EhValida())
            {
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

            var mensagem = new Mensagem();

            if (!professor.ValidaProfessor())
            {
                return View();
            }
            else
            {
                _professorRepository.Salvar(professor);
            }

            return RedirectToAction("cadastrarprofessor", "Admin");
        }

        [HttpPost]
        public IActionResult ExcluirProfessor(int idDoProfessor)
        {
            if (idDoProfessor > 0 && idDoProfessor.ToString() != "")
            {
                _professorRepository.Excluir(idDoProfessor);
            }
            return RedirectToAction("CadastrarProfessor", "Admin");
        }

        [HttpGet]
        public IActionResult EditarProfessor(int idDoprofessor)
        {
            //_professorRepository.BeginContext();
            var professor = _professorRepository.ObterProfessorPeloId(idDoprofessor);
            ViewBag.professor = professor;
            ViewBag.turmas = _turmaRepository.ListarTurmas();
            return View();
        }

        [HttpPost]
        public IActionResult AtualizarProfessor(int id, string nome, string sobrenome, List<int> listaDeIdDasTurmas)
        {
            //_professorRepository.BeginContext();
            var professor = _professorRepository.ObterProfessorPeloId(id);
            professor.Nome = nome;
            professor.Sobrenome = sobrenome;

            if (listaDeIdDasTurmas == null || listaDeIdDasTurmas.Count() == 0)
                return View();

            professor.Turmas = new List<ProfessorTurma>();

            foreach (var turmaId in listaDeIdDasTurmas)
            {
                Turma turma = _turmaRepository.ObterTurmaPeloId(turmaId);

                if (turma == null || turma.Id == 0)
                    return View();

                //var professorturma = new ProfessorTurma();
                //
                //professorturma.TurmaId = turma.Id;

                professor.Turmas.Add(new ProfessorTurma() { TurmaId = turma.Id });
            }

            if (!professor.ValidaProfessor())
            {
                ViewData["Message"] = "Envie os dados do professor de forma correta!";
                return View();
            }
            else
            {
                _professorRepository.Atualizar(professor);
            }

            //_professorRepository.EndContext();

            return RedirectToAction("cadastrarprofessor", "Admin");
        }

        [HttpGet]
        public IActionResult CadastrarQuestionario()
        {
            ViewBag.perguntas = _perguntaRepository.ListarPerguntas();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarQuestionario(QuestionarioCadastroViewModel questionarioCadastro)
        {
            string Nome = questionarioCadastro.NomeDoQuestionario;

            Periodo periodo = new Periodo();
            periodo.DataInicial = questionarioCadastro.PeriodoInicial;
            periodo.DataFinal = questionarioCadastro.PeriodoFinal;
            
            Questionario questionario = new Questionario() { Periodo = periodo };
            questionario.Nome = Nome;

            if (questionarioCadastro.ListaDeIdDePerguntas == null || questionarioCadastro.ListaDeIdDePerguntas.Count() == 0)
            {
                TempData["ErroPerguntaVazia"] = "O questionario precisa de perguntas para ser cadastrado.";
                return RedirectToAction("CadastrarQuestionario", "Admin");
            }

            foreach (var perguntaId in questionarioCadastro.ListaDeIdDePerguntas)
            {
                Pergunta pergunta = new Pergunta();
                pergunta = _perguntaRepository.ObterPerguntaPeloId(perguntaId);
                if (pergunta == null || pergunta.Id == 0) return View();

                var questionarioPergunta = new QuestionarioPergunta();
                questionarioPergunta.PerguntaId = pergunta.Id;
                questionarioPergunta.QuestionarioId = questionario.Id;

                questionario.Perguntas = new List<QuestionarioPergunta>();
                questionario.Perguntas.Add(questionarioPergunta);
            }

            if (questionario.EhValido())
            {
                _questionarioRepository.Salvar(questionario);
            }
            else
            {
                TempData["ErroQuestionario"] = "Por favor verifique se todos os campos foram preenchidos.";
                return RedirectToAction("CadastrarQuestionario", "Admin");
            }

            TempData["SucessoQuestionario"] = "Questionario cadastrado com sucesso.";
            return RedirectToAction("CadastrarQuestionario", "Admin");
        }

        [HttpGet]
        public IActionResult ListarQuestionario()
        {
            var questionarios = _questionarioRepository.ListarQuestionarios();

            var mensagem = new Mensagem();
            if (questionarios == null)
                return View(mensagem.QuestionarioNaoExiste());

            var viewModel = new QuestionarioListaViewModel()
            {
                NomeDoQuestionario = new List<string>(),
                Questionarios = new List<int>()
            };

            foreach (var nome in questionarios)
                viewModel.NomeDoQuestionario.Add(nome.Nome);
            if (viewModel.NomeDoQuestionario == null)
                return View(mensagem.QuestionarioNaoExiste());

            foreach (var questionario in questionarios)
                viewModel.Questionarios.Add(questionario.Id);
            if (viewModel.Questionarios == null)
                return View(mensagem.QuestionarioNaoExiste());
                        
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CadastrarPergunta()
        {
            ViewBag.perguntas = _perguntaRepository.ListarPerguntas();
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarPergunta(string perguntaEnviada)
        {
            Pergunta pergunta = new Pergunta(perguntaEnviada);
            var mensagem = new Mensagem();

            if (pergunta.EhValida())
            {
                _perguntaRepository.Salvar(pergunta);
            }
            else
            {
                return View();
            }

            return RedirectToAction("CadastrarPergunta", "Admin");
        }

        [HttpPost]
        public IActionResult DeletarPergunta(int id)
        {

            if (id > 0 && id.ToString() != "")
            {
                _perguntaRepository.Deletar(id);
            }

            return RedirectToAction("CadastrarPergunta", "Admin");
        }

        [HttpGet]
        public IActionResult PaginaDeAtualizarPergunta(int id)
        {
            ViewBag.Pergunta = _perguntaRepository.ObterPerguntaPeloId(id);
            return View();
        }

        [HttpPost]
        public IActionResult AtualizarPergunta(string texto, int id)
        {

            Pergunta pergunta = new Pergunta { Texto = texto, Id = id };
            if (pergunta.EhValida())
            {
                pergunta = _perguntaRepository.ObterPerguntaPeloId(id);
                pergunta.Texto = texto;
                _perguntaRepository.Atualizar(pergunta);
            }
            else
            {
                ViewBag.Mensagem = "Tentativa de atualizar pergunta inválida!";
                return RedirectToAction("CadastrarPergunta", "Admin");
            }

            return RedirectToAction("CadastrarPergunta", "Admin");
        }

    }
}
