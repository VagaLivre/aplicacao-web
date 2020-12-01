using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Spatial;
using System.Data.Entity.Spatial;
using System.Web;
using System.Resources;

namespace WebEstacionamentoTcc20.Models
{
    public class Empresa {

      
        public int EmpresaId { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public int NVagas { get; set; }
        public int NDispo { get; set; }
        public decimal Valor { get; set; }
        public TimeSpan Horafi { get; set; }
        public TimeSpan Horai { get; set; }
        public bool Seg { get; set; }
        public bool TER { get; set; }
        public bool Qua { get; set; }
        public bool Qui { get; set; }
        public bool Sex { get; set; }
        public bool Sab { get; set; }
        public bool Dom { get; set; }
      

       

        public class EmpresaCreateViewModel
        {
            [Key]
            public int EmpresaId { get; set; }

            [Index("RazaoSocialIndex", IsUnique = true)]
            [Display(Name = "RazaoSocial")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
            public string RazaoSocial { get; set; }

            [Display(Name = "NomeFantasia")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
            public string NomeFantasia { get; set; }

            [Display(Name = "Cpf")]
            public string Cpf { get; set; }

            [Display(Name = "Cnpj")]
            public string Cnpj { get; set; }

            [Display(Name = "Data_Cadastro")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime Data_Cadastro { get; set; }

            [Display(Name = "Endereco")]
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
            [Display(Name = "teste")]
            public String teste { get; set; }

            [Display(Name = "NVagas")]
            public int NVagas { get; set; }

            [Display(Name = "NDispo")]
            public int NDispo { get; set; }

            [Display(Name = "Valor")]
            [DataType(DataType.Currency)]
            [Required(ErrorMessage = "O campo Valor é requerido!!")]
            [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]

            public decimal Valor { get; set; }

            [Display(Name = "Horafi")]
            [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
            public TimeSpan Horafi { get; set; }
            [Display(Name = "Horai")]
        
            [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
            public TimeSpan Horai { get; set; }
            [Display(Name = "SEG")]
            public bool Seg { get; set; }

            [Display(Name = "TER")]
            public bool TER { get; set; }

            [Display(Name = "Qua")]
            public bool Qua { get; set; }

            [Display(Name = "Qui")]
            public bool Qui { get; set; }

            [Display(Name = "Sex")]
            public bool Sex { get; set; }

            [Display(Name = "Sab")]
            public bool Sab { get; set; }

            [Display(Name = "Dom")]
            public bool Dom { get; set; }
            

        }



      public class EmpresaEditViewModel
        {
            [Key]
            public int EmpresaId { get; set; }

            [Index("RazaoSocialIndex", IsUnique = true)]
            [Display(Name = "RazaoSocial")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
            public string RazaoSocial { get; set; }

            [Display(Name = "NomeFantasia")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
            public string NomeFantasia { get; set; }

            [Display(Name = "Cpf")]
            public string Cpf { get; set; }

            [Display(Name = "Cnpj")]
            public string Cnpj { get; set; }

            [Display(Name = "Data_Cadastro")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime Data_Cadastro { get; set; }

            [Display(Name = "Endereco")]
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

            

            [Display(Name = "NVagas")]
            public int NVagas { get; set; }

            [Display(Name = "NDispo")]
            public int NDispo { get; set; }



            [Display(Name = "Valor")]
            [DataType(DataType.Currency)]
            [Required(ErrorMessage = "O campo Valor é requerido!!")]
            [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]

            public decimal Valor { get; set; }


            [Display(Name = "Horafi")]
            [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
            public TimeSpan Horafi { get; set; }
            [Display(Name = "Horai")]

            [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
            public TimeSpan Horai { get; set; }
            [Display(Name = "SEG")]
            public bool Seg { get; set; }

            [Display(Name = "TER")]
            public bool TER { get; set; }

            [Display(Name = "Qua")]
            public bool Qua { get; set; }

            [Display(Name = "Qui")]
            public bool Qui { get; set; }

            [Display(Name = "Sex")]
            public bool Sex { get; set; }

            [Display(Name = "Sab")]
            public bool Sab { get; set; }

            [Display(Name = "Dom")]
            public bool Dom { get; set; }


            

        }


        public class EmpresaDeleteViewModel
        {
            [Key]
            public int EmpresaId { get; set; }

            [Index("RazaoSocialIndex", IsUnique = true)]
            [Display(Name = "RazaoSocial")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
            public string RazaoSocial { get; set; }

            [Display(Name = "NomeFantasia")]
            [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
            [StringLength(50, ErrorMessage = " O Campo {0} pode ter no máximo {1} e minimo {2} caracteres ", MinimumLength = 2)]
            public string NomeFantasia { get; set; }

            [Display(Name = "Cpf")]
            public string Cpf { get; set; }

            [Display(Name = "Cnpj")]
            public string Cnpj { get; set; }


            [Display(Name = "Data_Cadastro")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime Data_Cadastro { get; set; }

            [Display(Name = "Endereco")]
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

          


            [Display(Name = "NVagas")]
            public int NVagas { get; set; }

            [Display(Name = "NDispo")]
            public int NDispo { get; set; }



            [Display(Name = "Valor")]
            [DataType(DataType.Currency)]
            [Required(ErrorMessage = "O campo Valor é requerido!!")]
            [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]

            public decimal Valor { get; set; }


            [Display(Name = "Horafi")]
            [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
            public TimeSpan Horafi { get; set; }
            [Display(Name = "Horai")]

            [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
            public TimeSpan Horai { get; set; }
            [Display(Name = "SEG")]
            public bool Seg { get; set; }

            [Display(Name = "TER")]
            public bool TER { get; set; }

            [Display(Name = "Qua")]
            public bool Qua { get; set; }

            [Display(Name = "Qui")]
            public bool Qui { get; set; }

            [Display(Name = "Sex")]
            public bool Sex { get; set; }

            [Display(Name = "Sab")]
            public bool Sab { get; set; }

            [Display(Name = "Dom")]
            public bool Dom { get; set; }


            
        }


        public class EmpresaDisplayViewModel
        {
            public int EmpresaId { get; set; }
            public string RazaoSocial { get; set; }
            public string NomeFantasia { get; set; }
            public string Cpf { get; set; }
            public string Cnpj { get; set; }
            public DateTime Data_Cadastro { get; set; }
            public string Endereco { get; set; }
           
            public string Cidade { get; set; }
            public string UF { get; set; }
            public string CEP { get; set; }
            public String Latitude { get; set; }
            public String Longitude { get; set; }
          
            public int NVagas { get; set; }
            public int NDispo { get; set; }
            public decimal Valor { get; set; }
            public TimeSpan Horafi { get; set; }
            public TimeSpan Horai { get; set; }
            public bool Seg { get; set; }
            public bool TER { get; set; }
            public bool Qua { get; set; }
            public bool Qui { get; set; }
            public bool Sex { get; set; }
            public bool Sab { get; set; }
            public bool Dom { get; set; }

           

        }


        }
    }