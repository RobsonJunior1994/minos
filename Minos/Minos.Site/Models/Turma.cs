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
        public List<Questionario> Questionarios { get; set; }

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
            string codigo = DateTime.Now.ToString("yyMMddHHmm");
            codigo = codigo.Replace("/", "").Replace(":", "").Replace(" ","");

            switch (Grau)
            {
                case Grau.Fundamental:
                    codigo += "EF";
                    switch (Serie)
                    {
                        case Serie.Quinto:
                            codigo += "5";
                            break;

                        case Serie.Sexto:
                            codigo += "6";
                            break;

                        case Serie.Setimo:
                            codigo += "7";
                            break;

                        case Serie.Oitavo:
                            codigo += "8";
                            break;

                        case Serie.Nono:
                            codigo += "9";
                            break;

                        default:
                            break;
                    }
                    break;

                case Grau.Medio:
                    codigo += "EM";
                    switch (Serie)
                    {
                        case Serie.Primeiro:
                            codigo += "1";
                            break;

                        case Serie.Segundo:
                            codigo += "2";
                            break;

                        case Serie.Terceiro:
                            codigo += "3";
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
                    codigo += "M";
                    break;

                case Turno.Tarde:
                    codigo += "T";
                    break;

                default:
                    break;
            }

            return codigo;
        }

        public bool EhCodigoValido()
        {
            if (!CodigoTurma.Any(x => char.IsLetterOrDigit(x)))
            {
                return false;
            }
            else
            {
                return true;
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
