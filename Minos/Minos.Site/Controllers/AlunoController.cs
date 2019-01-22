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
        private IQuestionarioRepository _questionarioRepository;
        
        public AlunoController(
            IQuestionarioRepository questionarioRepository)
        {
            _questionarioRepository = questionarioRepository;
        }

        public IActionResult Index()
        {
            var logado = HttpContext.Session.GetString("LogarAluno");
            if (logado == null || logado.ToString() != logado.ToString())
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
    }
}