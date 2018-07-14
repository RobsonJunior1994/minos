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
            //Não sei como colocar para comparar o Enum Grau .
            if (string.IsNullOrEmpty(Serie) || Grau == Grau.Nenhum)
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
