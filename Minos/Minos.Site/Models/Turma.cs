using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Turma
    {
        public int Id { get; set; }
        [Required]
        public string CodigoTurma { get; set; }
        public Turno Turno { get; set; }
        public Serie Serie { get; set; }
        public Grau Grau { get; set; }
        public virtual IList<ProfessorTurma> Professores { get; set; }
        public virtual IList<Questionario> Questionarios { get; set; }

        public Turma(Grau grau, Serie serie, Turno turno, string codigoTurma)
        {
            Grau = grau;
            Serie = serie;
            Turno = turno;
            Professores = new List<ProfessorTurma>();

            if (string.IsNullOrEmpty(codigoTurma))
            {
                CodigoTurma = GerarCodigo();
                return;
            }
            else
            {
                CodigoTurma = codigoTurma;
            }

        }

        public Turma()
        {

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
                        case Serie.PrimeiroAnoEM:
                            codigo += "1";
                            break;

                        case Serie.SegundoAnoEM:
                            codigo += "2";
                            break;

                        case Serie.TerceiroAnoEM:
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
                (Grau == Grau.Fundamental && Serie == Serie.PrimeiroAnoEM) ||
                (Grau == Grau.Fundamental && Serie == Serie.SegundoAnoEM) ||
                (Grau == Grau.Fundamental && Serie == Serie.TerceiroAnoEM))
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
