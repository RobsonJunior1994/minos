using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Login(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public bool EhValido()
        {
            if(Usuario == "" || Usuario == null || Senha == "" || Senha == null)
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
