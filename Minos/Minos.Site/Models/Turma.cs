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
            string codigo = DateTime.Now.ToString("yyyyMMddHHmm");
            codigo = codigo.Replace("/", "").Replace(":", "").Replace(" ","");

            return codigo;
        }

        public string EscolherTurma()
        {
            switch (Grau)
            {
                case Grau.Fundamental:
                    
                    switch (Serie)
                    {
                        case Serie.Quinto:
                            break;
                        case Serie.Sexto:
                            break;
                        case Serie.Setimo:
                            break;
                        case Serie.Oitavo:
                            break;
                        case Serie.Nono:
                            break;
                        default:
                            break;
                    }
                    break;

                case Grau.Medio:
                    switch (Serie)
                    {
                        case Serie.Primeiro:
                            break;
                        case Serie.Segundo:
                            break;
                        case Serie.Terceiro:
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
                    break;
                case Turno.Tarde:
                    break;
                default:
                    break;
            }
            return null;
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
