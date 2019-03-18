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
        public virtual IList<QuestionarioTurma> Questionarios { get; set; }
        public bool Ativo { get; internal set; }

        public Turma(Grau grau, Serie serie, Turno turno, string codigoTurma)
        {
            Grau = grau;
            Serie = serie;
            Turno = turno;
            Professores = new List<ProfessorTurma>();
            Questionarios = new List<QuestionarioTurma>();

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
                        case Serie.SextoAno:
                            codigo += "6";
                            break;

                        case Serie.SetimoAno:
                            codigo += "7";
                            break;

                        case Serie.OitavoAno:
                            codigo += "8";
                            break;

                        case Serie.NonoAno:
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
                        case Serie.PrimeiroAno:
                            codigo += "1";
                            break;

                        case Serie.SegundoAno:
                            codigo += "2";
                            break;

                        case Serie.TerceiroAno:
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
                (Grau == Grau.Medio && Serie == Serie.SextoAno) || (Grau == Grau.Medio && Serie == Serie.SetimoAno) ||
                (Grau == Grau.Medio && Serie == Serie.OitavoAno) || (Grau == Grau.Medio && Serie == Serie.NonoAno) ||
                (Grau == Grau.Fundamental && Serie == Serie.PrimeiroAno) ||
                (Grau == Grau.Fundamental && Serie == Serie.SegundoAno) ||
                (Grau == Grau.Fundamental && Serie == Serie.TerceiroAno))
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
