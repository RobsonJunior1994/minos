using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minos.Site.Models;

namespace Minos.Site.Controllers
{
    public class AdminController : Controller
    {
        private IProfessorRepository _professorRepository;

        public AdminController(
            IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarProfessor(string nome, string sobrenome)
        {
            // Se nome/sobrenome contiver algum numero dentro da sua sequência de string devolver uma msg de erro.
            //if (nome /*é um numero ?*/ || sobrenome /* É um numero?*/)
            // any == qualquer
            if (nome.Any(char.IsDigit) || sobrenome.Any(char.IsDigit))
            {
                //Enviar msg de erro
            }
            else
            {
                Professor professor = new Professor(nome, sobrenome);

                _professorRepository.Salvar(professor);
            }
                  
            return View();
        }
    }
}