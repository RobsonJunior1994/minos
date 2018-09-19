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

        public bool Existe(string login, string senha)
        {
            bool usuarioExiste = false;
            using (var contexto = new MinosContext())
            {
                Usuario usuario = new Usuario(login, senha);
                var teste = contexto.Usuarios.Contains(usuario);
                if (teste)
                {
                    usuarioExiste = true;
                }
                usuarioExiste = false;
            }

            return usuarioExiste;
        }

        public void Salvar(Usuario usuario)
        {
            using (var contexto = new MinosContext())
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
            }
        }
    }
}
