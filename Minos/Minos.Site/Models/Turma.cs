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
        public string CodigoDaTurma { get; set; }
        public Turno Turno { get; set; }
        public Serie Serie { get; set; }
        public Grau Grau { get; set; }
        public virtual IList<ProfessorTurma> Professores { get; set; }

        public Turma(Grau grau, Serie serie, Turno turno, string codigoTurma)
        {
            Grau = grau;
            Serie = serie;
            Turno = turno;
            Professores = new List<ProfessorTurma>();

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
