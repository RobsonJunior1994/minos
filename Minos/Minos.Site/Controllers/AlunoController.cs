using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Minos.Site.Controllers
{
    public class AlunoController : Controller
    {
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