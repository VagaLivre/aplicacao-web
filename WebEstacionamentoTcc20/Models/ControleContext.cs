using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEstacionamentoTcc20.Models
{
    public class ControleContext : DbContext
    {
        // GET: ControleContext
        
      public ControleContext() : base("DefaultConnection")
        {
           

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public System.Data.Entity.DbSet<WebEstacionamentoTcc20.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<WebEstacionamentoTcc20.Models.Empresa> Empresas { get; set; }

        public System.Data.Entity.DbSet<WebEstacionamentoTcc20.Models.Ticket> Tickets { get; set; }

        public System.Data.Entity.DbSet<WebEstacionamentoTcc20.Models.GrupoAcesso> GrupoAcessoes { get; set; }
    }
}