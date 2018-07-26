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
        
        public IActionResult CadastrarTurma(Serie serie, Grau grau)
        {
            Turma turma = new Turma(serie, grau);

            if (!turma.ValidaTurma())
            {  
                ViewData["Message"] = "Por favor, preencha todos os campos necessários!";
                return View();
            }
            else
            {
                _turmaRepository.Salvar(turma);
            }
            return View();


        }

       
        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            List<Turma> turmas = _turmaRepository.ObterTurmasDesteAno();

            return View(turmas);
        }

        [HttpPost]
        public IActionResult CadastrarProfessor(string nome, string sobrenome, List<int> listaDeIdDasTurmas)
        {

            Professor professor = new Professor(nome, sobrenome);
            if (listaDeIdDasTurmas == null || listaDeIdDasTurmas.Count() == 0)
                return View();

            foreach (var turmaId in listaDeIdDasTurmas)
            {
                Turma turma = _turmaRepository.ObterTurmaPeloId(turmaId);

                if (turma == null || turma.Id == 0)
                    return View();

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