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
        public Turno Turno { get; set; }
        public Serie Serie { get; set; }
        public Grau Grau { get; set; }
        public IList<Professor> Professores { get; set; }

        public Turma(Grau grau, Serie serie, Turno turno, string codigoTurma)
        {
            Grau = grau;
            Serie = serie;
            Turno = turno;
            Professores = new List<Professor>();

            if (string.IsNullOrEmpty(codigoTurma))
                CodigoTurma = GerarCodigo();
            else
                CodigoTurma = codigoTurma;

        }

        public string GerarCodigo()
        {
            string codigo1 = null;
            string codigo2 = null;
            string codigo3 = null;
            string codigo = null;
            int contador = 0;
            codigo = String.Format("{0:00}{1}{2}{3}", contador++, codigo1, codigo2, codigo3);
            switch (Grau)
            {
                case Grau.Fundamental:
                    codigo1 += "EF";
                    switch (Serie)
                    {
                        case Serie.Sexto:
                            codigo2 += 6;
                            break;
                        case Serie.Setimo:
                            codigo2 += 7;
                            break;
                        case Serie.Oitavo:
                            codigo2 += 8;
                            break;
                        case Serie.Nono:
                            codigo2 += 9;
                            break;
                        default:
                            break;
                    }
                    break;

                case Grau.Medio:
                    codigo1 += "EM";
                    switch (Serie)
                    {
                        case Serie.Primeiro:
                            codigo2 += 1;
                            break;
                        case Serie.Segundo:
                            codigo2 += 2;
                            break;
                        case Serie.Terceiro:
                            codigo2 += 3;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            switch (Turno)
            {
                case Turno.Manha:
                    codigo3 += "M";
                    break;
                case Turno.Tarde:
                    codigo3 += "T";
                    break;
                case Turno.Noite:
                    codigo3 += "N";
                    break;
                default:
                    break;
            }
            codigo = String.Format("{0:00}{1}{2}{3}", contador++, codigo1, codigo2, codigo3);
            return codigo;
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

        public bool EhValida()
        {
            if (Grau == Grau.Nenhum || Serie == Serie.Nenhuma || Turno == Turno.Nenhum ||
                (Grau == Grau.Medio && Serie == Serie.Sexto) || (Grau == Grau.Medio && Serie == Serie.Setimo) ||
                (Grau == Grau.Medio && Serie == Serie.Oitavo) || (Grau == Grau.Medio && Serie == Serie.Nono) ||
                (Grau == Grau.Fundamental && Serie == Serie.Primeiro) ||
                (Grau == Grau.Fundamental && Serie == Serie.Segundo) ||
                (Grau == Grau.Fundamental && Serie == Serie.Terceiro))
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
