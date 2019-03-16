using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Minos.Site.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Admin { get; set; }

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
            if(string.IsNullOrEmpty(Login) || Login.Count() >= 20 || Login.Count() < 5 || Login.Contains(" "))
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
            if (string.IsNullOrEmpty(Senha) || Senha.Count() >= 15 || Senha.Count() < 5 || Senha.Contains(" "))
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
            }
            else
            {
                return false;
            }
        }

        public string GerarSenha()
        {
            Random random = new Random();
            string senhaAleatoria = "";
            for (int i = 0; i < 10; i++)
            {
                int num = random.Next(0, 10);
                senhaAleatoria = senhaAleatoria + Convert.ToString(num);
            }
            return senhaAleatoria;
        }

    }
}
