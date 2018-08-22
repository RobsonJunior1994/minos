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
            string codigo = null;
            //int _contador = 0;
            //codigo = codigo.Insert(2, _contador++);
            switch (Grau)
            {
                case Grau.Fundamental:
                    codigo += "A";
                    switch (Serie)
                    {
                        case Serie.Sexto:
                            codigo += 6;
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
                    break;

                case Grau.Medio:
                    codigo += "B";
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
                case Turno.Noite:
                    codigo += "N";
                    break;
                default:
                    break;
            }
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
