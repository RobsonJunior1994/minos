using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Minos.Site.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(string usuario, string senha)
        {
            return View();
        }
    }
}