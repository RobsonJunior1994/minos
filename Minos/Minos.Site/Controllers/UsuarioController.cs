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

        public UsuarioController(
            IUsuarioRepository usuarioRepository)
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
            var mensagem = new Mensagem();

            if (!usuario.ValidaLogin())
            {
                return View(mensagem.LoginInvalido());
            }

            if (!usuario.ValidaSenha())
            {
                return View(mensagem.SenhaInvalida());
            }
            
            _usuarioRepository.Salvar(usuario);
            
            return View(mensagem.SenhaLoginValido());

        }

    }
}