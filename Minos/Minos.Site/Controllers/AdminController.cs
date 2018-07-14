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
        private ITurmaRepository _turmaRepository;

        public AdminController(
            IProfessorRepository professorRepository,
            ITurmaRepository turmaRepository)
        {
            _professorRepository = professorRepository;
            _turmaRepository = turmaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarProfessor(string nome, string sobrenome, int turmaId)
        {

            Professor professor = new Professor(nome, sobrenome);
            Turma turma = _turmaRepository.ObterTurmaPeloId(turmaId);

            if (!professor.ValidaProfessor() || !turma.ValidaTurmas())
            {
                ViewData["Message"] = "Envie os dados do professor de forma correta!";
                return View();
            }
            else
            {
                _professorRepository.Salvar(professor);
            }
                  
            return View();
        }
    }
}