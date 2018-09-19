using Minos.Site.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public interface IUsuarioRepository 
    {
        void Salvar(Usuario usuario);
        bool DadosDeLoginSaoValidos(string login, string senha);
        bool Existe(string login, string senha);
    }
}
