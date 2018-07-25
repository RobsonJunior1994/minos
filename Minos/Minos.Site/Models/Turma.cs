using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public Serie Serie { get; set; }
        public Grau Grau { get; set; }
        public IList<Professor> Professores { get; set; }

        public Turma(Serie serie, Grau grau)
        {
            Serie = serie;
            Grau = grau;
            Professores = new List<Professor>();
        }
        
        public bool ValidaTurma()
        {
            if (Serie == Serie.Nenhuma || Grau == Grau.Nenhum)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
