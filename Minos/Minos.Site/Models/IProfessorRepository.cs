using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public interface IProfessorRepository
    {
        void Salvar(Professor professor);
        List<Professor> ListarProfessores();
        void Excluir(int id);
    }
}
