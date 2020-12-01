using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEstacionamentoTcc20.Models
{
    public class GrupoDetalhes

    {

        [Key]

        public int GrupoDetalhesId { get; set; }

        public int GrupoId { get; set; }

        public string idusercpt { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Usuario UsuarioApp { get; set; }

        public string GrupoUsuarioApp { get { return string.Format("{0} / {1}", Grupo.Descricao, UsuarioApp.NomeCompleto); } }

       // public virtual ICollection<Notas> Notas { get; set; }

    }
}