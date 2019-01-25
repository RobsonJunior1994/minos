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
                turma.Ativo = true;
                _turmaRepository.Salvar(turma);
            }

            return View();
        }

        [HttpPost]
        public IActionResult DesativarTurma (int id)
        {
            if(id == 0)
            {
                TempData["MensagemDanger"] = "Ocorreu um erro ao tentar desativar turma, por favor tente novamente";
                return RedirectToAction("ListaDeTurmas", "Admin");
                
            }

            Turma turma = _turmaRepository.ObterTurmaPeloId(id);
            turma.Ativo = false;
            _turmaRepository.Atualizar(turma);
            TempData["MenssagemSucesso"] = "Turma desativada com sucesso";
            return RedirectToAction("ListaDeTurmas", "Admin");

        }

        [HttpGet]
        public IActionResult AtualizarTurma(int id)
        {
            ViewBag.Turma = _turmaRepository.ObterTurmaPeloId(id);
            return View();
        }

        [HttpPost]
        public IActionResult AtualizarTurma(int id, Grau grau, Serie serie, Turno turno)
        {
            Turma turma = _turmaRepository.ObterTurmaPeloId(id);
            turma.Grau = grau;
            turma.Serie = serie;
            turma.Turno = turno;
            if (turma.EhValida())
            {
                _turmaRepository.Atualizar(turma);

            }
            else
            {
                TempData["MenssagemDanger"] = "Turma não foi atualizada";
                return RedirectToAction("ListaDeTurmas", "Admin");
            }

            TempData["MenssagemSucesso"] = "Turma Atualizada com sucesso";
            return RedirectToAction("ListaDeTurmas", "Admin");
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
            {
                TempData["MenssagemErro"] = "Associe esse professor a turma(s), se não aparecer as" +
                "turmas para cadastrar, cadastre turmas primeiro e depois volte aqui para cadastrar professor";
                return RedirectToAction("cadastrarprofessor", "Admin");
            }


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
                TempData["MenssagemErro"] = "Prencha todas as informações de professor corretamente";
                return RedirectToAction("cadastrarprofessor", "Admin");
            }
            else
            {
                professor.Ativo = true;
                _professorRepository.Salvar(professor);
                TempData["MenssagemSucesso"] = "Professor cadastrado com sucesso!";
            }

            return RedirectToAction("cadastrarprofessor", "Admin");
        }

        [HttpPost]
        public IActionResult DesativarProfessor(int idDoProfessor)
        {
            if (idDoProfessor > 0)
            {
                Professor professor = _professorRepository.ObterProfessorPeloId(idDoProfessor);
                professor.Ativo = false;
                _professorRepository.Atualizar(professor);
                TempData["MenssagemSucesso"] = "Professor desativado com sucesso!";
            }
            else
            {
                TempData["MenssagemErro"] = "Falha na tentativa de desativar um professor";

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
            var listaQuestionarios = _questionarioRepository.ListarQuestionarios();

            var viewModelLista = new List<QuestionarioViewModel>();

            foreach (var questionario in listaQuestionarios)
            {
                var questionarioViewModel = new QuestionarioViewModel()
                {
                    IdDoQuestionario = questionario.Id,
                    NomeDoQuestionario = questionario.Nome
                };
                viewModelLista.Add(questionarioViewModel);
            }

            return View(viewModelLista);
        }

        [HttpGet]
        public IActionResult EditarQuestionario(int id)
        {
            var listaDePerguntas = _perguntaRepository.ListarPerguntas();
            var idQuestionario = _questionarioRepository.ObterQuestionarioPeloId(id);

            if(idQuestionario.Id <= 0 || idQuestionario == null)
            {
                TempData["ErroNaoExisteQuestionario"] = "Por favor verifique se o questionario existe.";
                return RedirectToAction("ListarQuestionario", "Admin");
            }

            var viewModel = new QuestionarioUpdateViewModel()
            {
                NomeDoQuestionario = idQuestionario.Nome,
                IdDoQuestionario = idQuestionario.Id,
                Perguntas = new List<string>(),
                IdDePerguntas = new List<int>()
            };

            foreach (var pergunta in listaDePerguntas)
                viewModel.Perguntas.Add(pergunta.Texto);

            foreach (var idPergunta in listaDePerguntas)
                viewModel.IdDePerguntas.Add(idPergunta.Id);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditarQuestionario(QuestionarioUpdateViewModel questionarioUpdate)
        {
            var nomeQuestionario = _questionarioRepository.ObterQuestionarioPeloId(questionarioUpdate.IdDoQuestionario);
            nomeQuestionario.Nome = questionarioUpdate.NomeDoQuestionario;

            if (string.IsNullOrEmpty(nomeQuestionario.Nome))
            {
                TempData["ErroAlteracaoQuestionario"] = "Alterações no questionario inválidas!";
                return RedirectToAction("EditarQuestionario", "Admin", new { id = nomeQuestionario.Id });
            }
            else
            {
                _questionarioRepository.Atualizar(nomeQuestionario);
            }
            TempData["SucessoAlteracaoQuestionario"] = "Alterações feitas com sucesso!";
            return RedirectToAction("EditarQuestionario", "Admin", new { id = nomeQuestionario.Id });
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
            pergunta.Ativo = true;
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
        public IActionResult DesativarPergunta(int id)
        {
            if (id == 0)
            {
                TempData["Mensagem"] = "Ocorreu um erro ao tentar desativar uma pergunta, por favor tente novamente";
                return RedirectToAction("CadastrarPergunta", "Admin");
            }

            TempData["Sucesso"] = "Pergunta desativada com sucesso!";
            Pergunta pergunta = _perguntaRepository.ObterPerguntaPeloId(id);
            pergunta.Ativo = false;
            _perguntaRepository.Atualizar(pergunta);
            return RedirectToAction("CadastrarPergunta", "Admin");
        }

        [HttpGet]
        public IActionResult AtualizarPergunta(int id)
        {
            ViewBag.Pergunta = _perguntaRepository.ObterPerguntaPeloId(id);
            return View();
        }

        [HttpPost]
        public IActionResult AtualizarPergunta(string texto, int id)
        {
            Pergunta pergunta = null;
            pergunta = _perguntaRepository.ObterPerguntaPeloId(id);
            pergunta.Texto = texto;
            if (pergunta.EhValida())
            {
                _perguntaRepository.Atualizar(pergunta);
            }
            else
            {
                TempData["Mensagem"] = "Tentativa de atualizar pergunta inválida!";
                return RedirectToAction("CadastrarPergunta", "Admin");
            }
            TempData["Sucesso"] = "Pergunta atualizada com sucesso!";
            return RedirectToAction("CadastrarPergunta", "Admin");
            
        }

    }
}
