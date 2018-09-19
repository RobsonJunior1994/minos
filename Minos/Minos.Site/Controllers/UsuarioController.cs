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
        public IActionResult CadastrarUsuario(string login, string senha, string repitaSenha)
        {
            Usuario usuario = new Usuario(login, senha);

            if (_usuarioRepository.DadosDeLoginSaoValidos(login, senha))
            {
                ViewData["Message"] = "Usuario já existe!";
                ViewData["Status"] = "bg-danger";
                return View();
            }

            if (!usuario.ValidaLogin())
            {
                ViewData["Message"] = "Por favor Digite um Login!";
                ViewData["Status"] = "bg-danger";
                return View();
            }

            if (!usuario.ValidaSenha())
            {
                ViewData["Message"] = "Por favor Digite uma Senha Válida!";
                ViewData["Status"] = "bg-danger";
                return View();
            }
            if (senha != repitaSenha)
            {
                ViewData["Message"] = "As senhas não são iguais!";
                ViewData["Status"] = "bg-warning";
                return View();
            }

            ViewData["Message"] = "Cadastro efetuado com sucesso!";
            ViewData["Status"] = "bg-success";
            _usuarioRepository.Salvar(usuario);
            
            return View();

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            Usuario usuario = new Usuario(login, senha);
            if (usuario.EhValido())
            {
                if (_usuarioRepository.DadosDeLoginSaoValidos(login, senha))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewData["Message"] = "Por favor verifique se todas as informações foram preenchidas corretamente!";
                    return View();
                }
            }
           
            return View();
        }

    }
}