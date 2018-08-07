using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string CodigoTurma { get; set; }
        public Serie Serie { get; set; }
        public Grau Grau { get; set; }
        public IList<Professor> Professores { get; set; }

        public Turma(Serie serie, Grau grau, string codigoTurma)
        {
            Serie = serie;
            Grau = grau;

            if (string.IsNullOrEmpty(codigoTurma))
                CodigoTurma = GerarCodigo();
            else
                CodigoTurma = codigoTurma;

            Professores = new List<Professor>();
        }

        public string GerarCodigo()
        {
            //string prefixo = "LUC";
            //
            //
            //
            return null;
        }

        public bool ValidaTurma()
        {
            if (Serie == Serie.Nenhuma || Grau == Grau.Nenhum || string.IsNullOrEmpty(CodigoTurma))
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
