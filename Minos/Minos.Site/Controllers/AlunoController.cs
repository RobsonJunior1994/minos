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
            if (logado == null || logado.ToString() != logado.ToString())
            {
                return RedirectToAction("Login", "Usuario");
            }

            string matricula = HttpContext.Session.GetString("Matricula");
            //Aluno AlunoLogado =_alunoRepository.ObterAlunoPorMatricula(matricula);
            
            return RedirectToAction("Index", "Questionario", new { matriculaDoAluno = matricula });
            
        }
    }
}