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
        private MinosContext _context;

        public UsuarioRepository(MinosContext contexto)
        {
            _context = contexto;
        }

        public bool DadosDeLoginSaoValidos(string login, string senha)
        {
            bool usuarioExiste = false;

            var usuarios = _context.Usuarios.SingleOrDefault(x => x.Login == login && x.Senha == senha);

            usuarioExiste = usuarios != null;

            return usuarioExiste;
        }

        public bool Existe(string login)
        {
            bool usuarioExiste = false;

            var usuarios = _context.Usuarios.SingleOrDefault(x => x.Login == login);

            usuarioExiste = usuarios != null;

            return usuarioExiste;
        }

        public void Salvar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

        }

        public bool EhAdm(string login, string senha)
        {
            bool usuarioEhAdm = false;

            var usuario = _context.Usuarios.SingleOrDefault(x => x.Login == login && x.Senha == senha && x.Admin == "S");
            usuarioEhAdm = usuario != null;

            return usuarioEhAdm;
        }
    }
}
