using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebEstacionamentoTcc20.Models
{
    public class Ticket {

        [Key]

        public int IdTicket { get; set; }

        [Display(Name = "Nome Usuario")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Codigo Usuario")]
        public int UserId { get; set; }

        [Display(Name = "Nome da Empresa")]
        public string NomeEmpresa { get; set; }

        [Display(Name = "Codigo Empresa")]
        public int EmpresaId { get; set; }

        

        
       




        public virtual Usuario Usuario { get; set; }

        public virtual Empresa Empresa { get; set; }


        [Display(Name = "Reserva_Finalizada")]
        public bool Reserva_F { get; set; }


        [Display(Name = "Check_in")]
       
        [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
        public TimeSpan Check_in { get; set; }
       

        [Display(Name = "Check_out")]
        [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
        public Nullable<TimeSpan> Check_out { get; set; }
        


        [Display(Name = "Data_Check_in")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data_Check_in { get; set; }
       

        [Display(Name = "Data_Check_out")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Data_Check_out { get; set; }
      

        [Display(Name = "TotalHoras")]
        [DisplayFormat(DataFormatString = "{0:%h}h {0:%m}", ApplyFormatInEditMode = true)]
        public TimeSpan TotalHoras { get; set; }
       


        [Display(Name = "ValorPorHora")]
        public float ValorPorHora { get; set; }
       

        [Display(Name = "ValorTotal")]
        public float ValorTotal { get; set; }
        

    }

}

    
