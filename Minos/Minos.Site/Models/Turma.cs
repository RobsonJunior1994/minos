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

        public string GerarCodigo()
        {
            string codigo = null;
            switch (Grau)
            {
                case Grau.Nenhum:
                    break;
                case Grau.Fundamental:
                    codigo += "A";
                    break;
                case Grau.Medio:
                    codigo += "B";
                    break;
            }
            switch (Serie)
            {
                case Serie.Nenhuma:
                    break;
                case Serie.Primeiro:
                    codigo += 10;
                    break;
                case Serie.Segundo:
                    codigo += 20;
                    break;
                case Serie.Terceiro:
                    codigo += 30;
                    break;
                case Serie.Setimo:
                    codigo += 70;
                    break;
                case Serie.Oitavo:
                    codigo += 80;
                    break;
                case Serie.Nono:
                    codigo += 90;
                    break;
            }
            switch (Periodo)
            {
                case Periodo.Nenhum:
                    break;
                case Periodo.Manhã:
                    codigo += "M";
                    break;
                case Periodo.Tarde:
                    codigo += "T";
                    break;
                case Periodo.Noite:
                    codigo += "N";
                    break;
            }

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
