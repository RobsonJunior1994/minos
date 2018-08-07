using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Pergunta
    {
        public string pergunta;

        public Pergunta(string _pergunta)
        {
            pergunta = _pergunta;
        }

        internal bool EhValida()
        {
            if (pergunta == null || pergunta.Length <= 10)
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
