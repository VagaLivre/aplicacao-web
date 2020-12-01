using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEstacionamentoTcc20.Models
{
    public class UsuarioView
    {
        public Usuario Usuario { get; set; }
        public HttpPostedFileBase Foto { get; set; } 
    }
}