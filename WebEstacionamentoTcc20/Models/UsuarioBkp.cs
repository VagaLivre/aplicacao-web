using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebEstacionamentoTcc20.Models
{
    public class UsuarioBkp
    {

        [Key]
        public int UserId { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]

        [DataType(DataType.EmailAddress)]
        [Index("UserNameIndex", IsUnique = true)]

        public string UserName { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

        public string Sobrenome { get; set; }
        [Display(Name = "Usuário")]

        public string NomeCompleto { get { return string.Format("{0} {1}", this.Nome, this.Sobrenome); } }
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(20, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 7)]

        public string Telefone { get; set; }
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        [StringLength(100, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 10)]

        public string Endereco { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Display(Name = "User app")]
        public bool UsuarioApp { get; set; }

        [Display(Name = "User estacionamento")]
        public bool UsuarioEst { get; set; }

        public virtual ICollection<Usuario> Usuariolist { get; set; }



        public class UsuarioEditViewModel
        {

            [Key]
            public int UserId { get; set; }

            [Display(Name = "E-Mail")]
            [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
            [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]

            [DataType(DataType.EmailAddress)]
            [Index("UserNameIndex", IsUnique = true)]

            public string UserName { get; set; }
            [Display(Name = "Nome")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

            public string Nome { get; set; }
            [Display(Name = "Sobrenome")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

            public string Sobrenome { get; set; }
            [Display(Name = "Usuário")]

            public string NomeCompleto { get { return string.Format("{0} {1}", this.Nome, this.Sobrenome); } }
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(20, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 7)]

            public string Telefone { get; set; }
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(100, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 10)]

            public string Endereco { get; set; }

            [Display(Name = "Cidade")]
            public string Cidade { get; set; }

            [Display(Name = "UF")]
            public string UF { get; set; }


            [Display(Name = "CEP")]
            public string Cep { get; set; }

            [Display(Name = "Latitude")]
            public String Latitude { get; set; }

            [Display(Name = "Longitude")]
            public String Longitude { get; set; }

            [Display(Name = "User app")]
            public bool UsuarioApp { get; set; }

            [Display(Name = "User estacionamento")]
            public bool UsuarioEst { get; set; }

            public virtual ICollection<Usuario> Usuariolist { get; set; }
        }

        public class UsuarioDeleteViewModel
        {

            [Key]
            public int UserId { get; set; }

            [Display(Name = "E-Mail")]
            [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
            [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]

            [DataType(DataType.EmailAddress)]
            [Index("UserNameIndex", IsUnique = true)]

            public string UserName { get; set; }
            [Display(Name = "Nome")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

            public string Nome { get; set; }
            [Display(Name = "Sobrenome")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

            public string Sobrenome { get; set; }
            [Display(Name = "Usuário")]

            public string NomeCompleto { get { return string.Format("{0} {1}", this.Nome, this.Sobrenome); } }
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(20, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 7)]

            public string Telefone { get; set; }
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(100, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 10)]

            public string Endereco { get; set; }

            [Display(Name = "Cidade")]
            public string Cidade { get; set; }

            [Display(Name = "UF")]
            public string UF { get; set; }


            [Display(Name = "CEP")]
            public string Cep { get; set; }

            [Display(Name = "Latitude")]
            public String Latitude { get; set; }

            [Display(Name = "Longitude")]
            public String Longitude { get; set; }
            [DataType(DataType.ImageUrl)]
            public string Photo { get; set; }

            [Display(Name = "User app")]
            public bool UsuarioApp { get; set; }

            [Display(Name = "User estacionamento")]
            public bool UsuarioEst { get; set; }

            public virtual ICollection<Usuario> Usuariolist { get; set; }
        }




        public class UsuarioCreateViewModel
        {

            [Key]
            public int UserId { get; set; }

            [Display(Name = "E-Mail")]
            [Required(ErrorMessage = "O Campo {0} é Obrigatório!")]
            [StringLength(100, ErrorMessage = "O Campo {0} pode ter no máximo {1} e minimo {2} caracteres", MinimumLength = 7)]

            [DataType(DataType.EmailAddress)]
            [Index("UserNameIndex", IsUnique = true)]

            public string UserName { get; set; }
            [Display(Name = "Nome")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

            public string Nome { get; set; }
            [Display(Name = "Sobrenome")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]

            public string Sobrenome { get; set; }
            [Display(Name = "Usuário")]

            public string NomeCompleto { get { return string.Format("{0} {1}", this.Nome, this.Sobrenome); } }
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(20, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 7)]

            public string Telefone { get; set; }
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(100, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 10)]

            public string Endereco { get; set; }

            [Display(Name = "Cidade")]
            public string Cidade { get; set; }

            [Display(Name = "UF")]
            public string UF { get; set; }


            [Display(Name = "CEP")]
            public string Cep { get; set; }

            [Display(Name = "Latitude")]
            public String Latitude { get; set; }

            [Display(Name = "Longitude")]
            public String Longitude { get; set; }

            [DataType(DataType.ImageUrl)]
            public string Photo { get; set; }

            [Display(Name = "User app")]
            public bool UsuarioApp { get; set; }

            [Display(Name = "User estacionamento")]
            public bool UsuarioEst { get; set; }

            public virtual ICollection<Usuario> Usuariolist { get; set; }
        }


        public class UsuarioDisplayViewModel
        {

            public int UserId { get; set; }

            public string UserName { get; set; }

            public string Nome { get; set; }

            public string Sobrenome { get; set; }

            public string NomeCompleto { get { return string.Format("{0} {1}", this.Nome, this.Sobrenome); } }

            public string Telefone { get; set; }

            public string Endereco { get; set; }

            public string Cidade { get; set; }
            public string UF { get; set; }
            public string CEP { get; set; }

            public string Photo { get; set; }

            public bool UsuarioApp { get; set; }

            public bool UsuarioEst { get; set; }



            



        }
    }
}