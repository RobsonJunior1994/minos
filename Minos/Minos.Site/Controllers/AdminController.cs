using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;

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
            var mensagem = new Mensagem();

            if (!turma.EhCodigoValido())
            {
                return View(mensagem.TurmaCodigoInvalido());
            }

            if (!turma.EhValida())
            {
                return View(mensagem.CadastroTurmaInvalido());
            }
            else
            {
                _turmaRepository.Salvar(turma);
            }
            return View(mensagem.CadastroTurmaValido());

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

            var mensagem = new Mensagem();

            if (!professor.ValidaProfessor())
            {
                return View(mensagem.CadastroProfessorIncorreto());
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
            var mensagem = new Mensagem();
            if (questionario.EhValido())
            {
                _questionarioRepository.Salvar(questionario);
            }
            else
            {
                return View(mensagem.CadastroQuestionarioIncorreto());
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
            var mensagem = new Mensagem();

            if (pergunta.EhValida())
            {
                _perguntaRepository.Salvar(pergunta);
            }
            else
            {
                return View(mensagem.CadastroPerguntaIncorreto());
            }

            return View();
        }
    }
}
