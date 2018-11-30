using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }
        
        //string exemploEmail = (@"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$");
        //string acima para ser usada posteriormente caso seja utilizado email para cadastro de usuario.
        
       public bool ValidaLogin()
       {
            if(string.IsNullOrEmpty(Login) || Login.Length >= 20 || Login.Length < 5)
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
            if (string.IsNullOrEmpty(Senha) || Senha.Length >= 15 || Senha.Length < 6)
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
