using AutoMapper;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebEstacionamentoTcc20.Data.Repositories.Interfaces;
using WebEstacionamentoTcc20.Data.Repositories.UO;
using WebEstacionamentoTcc20.Models;
using static WebEstacionamentoTcc20.Models.Empresa;

namespace WebEstacionamentoTcc20.Data.Repositories.Implementation
{
    public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository

    {

          static string strConexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private IConfiguration _config;

        

        public EmpresaRepository(UnitOfWork uo)
            : base(uo)
        {
           
        }



        public IEnumerable<Empresa> PesquisarPorUsuario(string usuariologado)
        {
         
            using (var conexaoBD = new SqlConnection(strConexao))
            {
                return conexaoBD.Query<Empresa>(
                    "SELECT * FROM   dbo.Empresas as e INNER JOIN dbo.GrupoAcessoes as g on e.EmpresaId = g.EmpresaId Where g.id ='"+ usuariologado + "'");
            }
        }

        public int PesquisarPorUsuariologin(string guiduser)
        {
            int idusuario;


            using (SqlConnection con = new SqlConnection(strConexao))
            {

                SqlCommand cmd = new SqlCommand("SELECT UserId FROM Usuarios Where id Like'%guiduser%'", con);



                cmd.Parameters.Add("@id", SqlDbType.Char).Value = guiduser;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();

                Usuario usuario;
                usuario = new Usuario();
                usuario.UserId = rdr.GetInt32(1); //primeira coluna
                idusuario = usuario.UserId;


                return idusuario;
            }



            }




          







      





    



        public IQueryable<Empresa> PesquisarPorLocal(string idUsuario)
        {
            return this._unitOfWork.Context.Empresas.Where(c => c.Endereco.Trim().Contains(idUsuario.Trim()));
        }
    }
}

