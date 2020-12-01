using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebEstacionamentoTcc20.Data.Repositories.Interfaces;
using WebEstacionamentoTcc20.Data.Repositories.UO;
using WebEstacionamentoTcc20.Models;

namespace WebEstacionamentoTcc20.Data.Repositories.Implementation
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {


        static string strConexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private IConfiguration _config;


        public UsuarioRepository(UnitOfWork uo)
            : base(uo)
        {

        }

        public IQueryable<Usuario> PesquisarPorLocal(string local)
        {
         return this._unitOfWork.Context.Usuarios.Where(c => c.Endereco.Trim().Contains(local.Trim()));
        }


        public IEnumerable<Usuario> PesquisarUsuariosCadastrados(string usuariologado)
        {






            using (var conexaoBD = new SqlConnection(strConexao))
            {
                return conexaoBD.Query<Usuario>(
                     "SELECT * FROM   dbo.Usuarios as e INNER JOIN dbo.GrupoAcessoes as g on e.id = g.id Where g.id like'"+ usuariologado + "'");
            }
        }
    }
}

