using Minos.Site.Controllers;
using Minos.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool DadosDeLoginSaoValidos(string login, string senha)
        {
            bool usuarioExiste = false;

            using (var repo = new MinosContext())
            {
                var usuarios = repo.Usuarios.SingleOrDefault(x => x.Login == login && x.Senha == senha);

                usuarioExiste = usuarios != null;
            }
            return usuarioExiste;
        }

        public void Salvar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
