using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public interface IAlunoRepository
    {
        Aluno ObterAlunoPorMatricula(string matriculaDoAluno);
        void Salvar(Aluno aluno);
        List<Aluno> ListaDeAlunos();
        void Desativar(string matricula);
        void Atualizar(string Matricula);

    }
}
