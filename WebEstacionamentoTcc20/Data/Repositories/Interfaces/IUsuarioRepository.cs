using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEstacionamentoTcc20.Models;

namespace WebEstacionamentoTcc20.Data.Repositories.Interfaces
{
    interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        IQueryable<Usuario> PesquisarPorLocal(string local);
    }
}