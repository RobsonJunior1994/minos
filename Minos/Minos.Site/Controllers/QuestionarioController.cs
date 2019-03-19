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
        public IActionResult Index(string matriculaDoAluno)
        {
            var aluno = _alunoRepository.ObterAlunoPorMatricula(matriculaDoAluno);

            var questionario =
                aluno
                .Turma
                .Questionarios
                .FirstOrDefault();

            var mensagem = new Mensagem();

            if (questionario == null)
            {
                return View(mensagem.QuestionarioNaoExiste());
            }

            var viewModel = new QuestionarioAlunoViewModel()
            {
                CodigoDaTurma = aluno.Turma.CodigoTurma,
                Matricula = aluno.Matricula,
                NomeDoAluno = aluno.Nome + " " + aluno.Sobrenome,
                Perguntas = new List<string>(),
                Professores = new List<string>()
            };

            var q =_questionarioRepository.ObterQuestionarioPeloId(questionario.QuestionarioId);// preciso retornar a lista de perguntas

            foreach (var perguntaClasse in q.Perguntas)
                viewModel.Perguntas.Add(perguntaClasse.Pergunta.Texto);

            foreach (var professorTurma in aluno.Turma.Professores)
                viewModel.Professores.Add(professorTurma.Professor.Nome + " " + professorTurma.Professor.Sobrenome);
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index()
        {
            Resposta resposta = new Resposta();
            var mensagem = new Mensagem();

            if (resposta.EhRespostaValida())
            {
                _respostaRepository.Salvar(resposta.Resultado());
            }
            else
            {
                return View(mensagem.RespostaIncorreta());
            }
            return View();
        }
    }
}