using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string CodigoDaTurma { get; set; }
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
            {
                CodigoDaTurma = GerarCodigo();
                return;
            }
            else
            {
                CodigoDaTurma = codigoTurma;
            }

        }

        public Turma()
        {

        }
        
        public bool EhCodigoValido()
        {
            if (CodigoDaTurma.Any(x => char.IsLetterOrDigit(x)))
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
                case Serie.PrimeiroAnoEM:
                    codigo += 1;
                    break;
                case Serie.SegundoAnoEM:
                    codigo += 2;
                    break;
                case Serie.TerceiroAnoEM:
                    codigo += 3;
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

        public bool EhValida()
        {
            if (Serie == Serie.Nenhuma || Grau == Grau.Nenhum || Turno == Turno.Nenhum)
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
