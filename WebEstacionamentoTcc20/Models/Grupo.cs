﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebEstacionamentoTcc20.Models
{
    public class Grupo

    {

        [Key]

        public int GrupoId { get; set; }

        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]

        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 3)]

        [Index("GrupoDescricaoIndex", IsUnique = true)]

        public string Descricao { get; set; }

        public int UserId { get; set; }

        public virtual Usuario UsuarioEst { get; set; }

        public virtual ICollection<GrupoDetalhes> GroupoDetalhes { get; set; }

    }
}