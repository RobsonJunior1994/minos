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
        public Periodo Periodo { get; set; }
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

        public bool EhCodigoValido()
        {
            if (CodigoTurma.Any(x => char.IsLetterOrDigit(x)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GerarCodigo()
        {
            string codigo = null;
            switch (Grau)
            {
                case Grau.Fundamental:
                    codigo += "A";
                    break;
                case Grau.Medio:
                    codigo += "B";
                    break;
                default:
                    break;
            }
            switch (Serie)
            {
                case Serie.Primeiro:
                    codigo += 1;
                    break;
                case Serie.Segundo:
                    codigo += 2;
                    break;
                case Serie.Terceiro:
                    codigo += 3;
                    break;
                case Serie.Setimo:
                    codigo += 7;
                    break;
                case Serie.Oitavo:
                    codigo += 8;
                    break;
                case Serie.Nono:
                    codigo += 9;
                    break;
                default:
                    break;
            }
            switch (Periodo)
            {
                case Periodo.Manha:
                    codigo += "M";
                    break;
                case Periodo.Tarde:
                    codigo += "T";
                    break;
                case Periodo.Noite:
                    codigo += "N";
                    break;
                default:
                    break;
            }
            return codigo;
        }

        public bool EhTurmaValida()
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
