using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;

namespace Minos.Site.Controllers
{
    public class AlunoController : Controller
    {
        private IAlunoRepository _alunoRepository;

        public AlunoController(
            IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        
        public IActionResult Index()
        {
            var logado = HttpContext.Session.GetString("LogarAluno");
            var aluno = _alunoRepository.ObterAlunoPorMatricula(logado);

            var viewModel = new AlunoIndexViewModel()
            {
                NomeDoAluno = aluno.Nome,
                MatriculaDoAluno = aluno.Matricula
            };

            if (logado == null ||
                logado.ToString() != logado.ToString())
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View(viewModel);
        }
    }
}