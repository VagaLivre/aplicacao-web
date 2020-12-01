using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebEstacionamentoTcc20.Models;

namespace WebEstacionamentoTcc20.Classes
{
    [NotMapped]
    public class UsuarioSenha :Usuario
    {
        [Required(ErrorMessage = " O Campo {0} é obrigatorioo!")]

        [StringLength(15, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
        public string senha { get; set; }


    }
}