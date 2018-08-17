using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;

namespace Minos.Site.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(string login, string senha)
        {
            Usuario usuario = new Usuario(login, senha);

            if (!usuario.ValidaLogin())
            {
                ViewData["Message"] = "Porfavor Digite um Login!";
                return View();
            }

            if (!usuario.ValidaSenha())
            {
                ViewData["Message"] = "Porfavor Digite uma Senha Válida!";
                return View();
            }

            ViewData["Message"] = "Login e Senha Válida";
            _usuarioRepository.Salvar(usuario);
            
            return View();

        }

    }
}