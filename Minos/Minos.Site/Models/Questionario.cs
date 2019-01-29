using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Questionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Periodo Periodo { get; set; } // <- para representar uma data!
        [Required]
        public List<QuestionarioPergunta> Perguntas { get; set; }
        public bool Ativo { get; internal set; }

        public Questionario() { }

        public Questionario(List<QuestionarioPergunta> perguntas, Periodo periodo)
        {
            Periodo = periodo;
            Perguntas = perguntas ?? new List<QuestionarioPergunta>();
        }
        
        public bool EhValido()
        {
            if ( string.IsNullOrEmpty(Nome) ||
                Periodo == null || Periodo.DataInicial == default || Periodo.DataInicial == null ||
                Periodo.DataFinal == null || Periodo.DataFinal == default || 
                Perguntas == null || Perguntas.Count <= 0 || 
                Periodo.DataInicial.Date > Periodo.DataFinal.Date || Periodo.DataInicial.Date > DateTime.Now.Date)
            {
                return false;
            }
            return true;
        }

    }
}
