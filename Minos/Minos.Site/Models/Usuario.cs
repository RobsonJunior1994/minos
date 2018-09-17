using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Minos.Site.Models;

namespace Minos.Site.Controllers
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public Usuario()
        {

        }
        
        //string exemploEmail = (@"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$");
        //string acima para ser usada posteriormente caso seja utilizado email para cadastro de usuario.
        
       public bool ValidaLogin()
       {
            if(string.IsNullOrEmpty(Login) || Login.Count() >= 20 || Login.Count() < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
       }

        public bool ValidaSenha()
        {
            if (string.IsNullOrEmpty(Senha) || Senha.Count() >= 15 || Senha.Count() < 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EhValido()
        {
            if(ValidaLogin() && ValidaSenha())
            {
                return true;
            } else
            {
                return false;
            }
        }

    }
}
