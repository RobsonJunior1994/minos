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

        public IActionResult CadastrarProfessor(string nome, string sobrenome, List<int> turmasId)
        {

            Professor professor = new Professor(nome, sobrenome);
            foreach (var turmaId in turmasId)
            {
                
                Turma turma = _turmaRepository.ObterTurmaPeloId(turmasId);
                professor.Turmas.Add(turma);

            }
            

            if (!professor.ValidaProfessor())
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