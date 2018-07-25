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
        public List<Perguntas> ListaDePerguntas { get; private set; }


        public Questionario(List<Perguntas> listaDePerguntas, Periodo periodo)
        {
            Periodo = periodo;
            ListaDePerguntas = listaDePerguntas;
        }


        public bool EhValido()
        {
            if (Periodo == null || Periodo.DataInicial == default || Periodo.DataFinal == default)
            {
                if(ListaDeTurmas == null || ListaDeTurmas.Count() <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        internal void Salvar()
        {
            //Implementar metodo de Salvar.
        }
    }
}
