using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEstacionamentoTcc20.Models
{
    public class GrupoAcesso
    {
        [Key]
        public int GrupoAcessoId { get; set; }
        public string id { get; set; }

        public int EmpresaId { get; set; }

      

     

        public virtual Empresa Empresa { get; set; }

    }
}