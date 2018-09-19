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
        public int Resposta { get; set; }


        public Questionario(List<Pergunta> listaDePerguntas,List<Turma> listaDeTurmas, Periodo periodo, int resposta)
        {
            Periodo = periodo;
            ListaDePerguntas = listaDePerguntas;
            ListaDeTurmas = listaDeTurmas;

            if (resposta == 0)
                Resposta = ResultadoQuest();

        }

        public int ResultadoQuest()
        {
            
            var resposta1 = false;
            var resposta2 = false;
            var resposta3 = false;
            var resposta4 = false;
            var resposta5 = false;
            int result = 0;

            if(resposta1 == true)
            {
                result = 1;
                if(resposta2 == true)
                {
                    result = 2;
                    if(resposta3 == true)
                    {
                        result = 3;
                        if(resposta4 == true)
                        {
                            result = 4;
                            if(resposta5 == true)
                            {
                                result = 5;
                            }
                        }
                    }
                }
            }
            return result;
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
