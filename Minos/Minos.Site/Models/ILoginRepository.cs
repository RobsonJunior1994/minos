using Minos.Site.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minos.Site.Models
{
    public interface ILoginRepository
    {
        void Entrar(Usuario usuario);
    }
}
