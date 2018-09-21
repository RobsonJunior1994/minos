using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Questionario
    {
        public Periodo Periodo { get; private set; } // <- para representar uma data!
        public List<Turma> ListaDeTurmas { get; private set; }
        public List<Pergunta> ListaDePerguntas { get; set; }


        public Questionario(List<Pergunta> listaDePerguntas, Periodo periodo)
        {
            Periodo = periodo;
            ListaDePerguntas = listaDePerguntas;
        }
        
        public bool EhValido()
        {
            if (Periodo == null || Periodo.DataInicial == default || 
                Periodo.DataFinal == default || ListaDePerguntas == null || 
                ListaDePerguntas.Count == 0 || Periodo.DataInicial.Date > Periodo.DataFinal.Date ||
                Periodo.DataInicial.Date < DateTime.Now.Date)
            {
                return false;
            }
            return true;
        }

    }
}
