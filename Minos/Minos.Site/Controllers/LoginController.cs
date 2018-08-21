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

        public IActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(string usuario, string senha)
        {
            Login login = new Login(usuario, senha);
            if (login.EhValido())
            {
                _loginRepository.Entrar(login);
            } 
                return View();
        }
    }
}