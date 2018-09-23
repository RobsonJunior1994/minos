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

        public bool Existe(string login)
        {
            bool usuarioExiste = false;

            using (var repo = new MinosContext())
            {
                var usuarios = repo.Usuarios.SingleOrDefault(x => x.Login == login);
                
                usuarioExiste = usuarios != null;
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

        public bool EhAdm(string login, string senha)
        {
            bool usuarioEhAdm = false;
            using (var contexto = new MinosContext())
            {
                var usuario = contexto.Usuarios.SingleOrDefault(x => x.Login == login && x.Senha == senha && x.Admin == "S");
                usuarioEhAdm = usuario != null;
            }
            return usuarioEhAdm;
        }
    }
}
