using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public Grau Grau { get; set; }
        public IList<Professor> Professores { get; set; }

        public Turma(string serie, Grau grau)
        {
            Serie = serie;
            this.Grau = grau;
        }
        
        public bool ValidaTurmas()
        {
            if (string.IsNullOrEmpty(Serie))
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
