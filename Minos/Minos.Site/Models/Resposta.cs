using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Resposta
    {
        public int Id { get; set; }
        public int Opcao { get; set; }
        

        public Resposta() { }

        public int Resultado()
        {
            int result;

            if (Opcao == 1)
            {
                result = 1;
            }
            else if (Opcao == 2)
            {
                result = 2;
            }
            else if (Opcao == 3)
            {
                result = 3;
            }
            else if (Opcao == 4)
            {
                result = 4;
            }
            else if (Opcao == 5)
            {
                result = 5;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public bool EhRespostaValida()
        {
            if(Resultado() == 0)
            {
                return false;
            }
            return true;
        }
    }
}
