using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;

namespace Minos.Site.Controllers
{
    public class LoginController : Controller
    {
        private ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(string nomeDeUsuario, string senha)
        {
            Usuario usuario = new Usuario(nomeDeUsuario, senha);
            if (usuario.EhValido())
            {
                _loginRepository.Entrar(usuario);
                return View("AdminController");
            }   else
            {
                ViewData["Message"] = "Por favor verifique se todas as informações foram preenchidas corretamente!";
            }

            return View();
        }
    }
}