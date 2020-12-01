using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebEstacionamentoTcc20.Classes;
using WebEstacionamentoTcc20.Models;

namespace WebEstacionamentoTcc20.Controllers.API
{
    [RoutePrefix("API/Empresas")]

    public class EmpresasController : ApiController
    {
        private ControleContext db = new ControleContext();



        [HttpPost]
        [Route("Pesquisavaga")]
        public IHttpActionResult Pesquisavaga(JObject form)
        {
            string cidade = string.Empty;
            string uf = string.Empty;
            dynamic jsonObject = form;

            try
            {
                cidade = jsonObject.cidade.Value;
                uf = jsonObject.uf.Value;
            }
            catch
            {
                return this.BadRequest("Chamada Incorreta");
            }

            var db2 = new ControleContext();

          /*  var userASP = db2.Empresas.Where(gd => gd.Cidade == cidade).ToList(); ;
           


            if (userASP == null)
            {
                return this.BadRequest("Usuário ou Senha incorretos");
            }*/
            
            var user = db.Empresas
                .Where(u => u.Cidade == cidade).ToList();


            if (user == null)
            {
                return this.BadRequest("Cidade não possui estacionamento");
            }

            return this.Ok(user);
        }

        // GET: api/Empresas
        public IQueryable<Empresa> GetEmpresas()
        {
            return db.Empresas;
        }

        // GET: api/Empresas/5
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult GetEmpresa(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        // PUT: api/Empresas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpresa(int id, Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresa.EmpresaId)
            {
                return BadRequest();
            }

            db.Entry(empresa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

      /*  // POST: api/Empresas dada
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult PostEmpresa(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empresas.Add(empresa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empresa.EmpresaId }, empresa);
        }

    */


        // DELETE: api/Empresas/5
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult DeleteEmpresa(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return NotFound();
            }

            db.Empresas.Remove(empresa);
            db.SaveChanges();

            return Ok(empresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresaExists(int id)
        {
            return db.Empresas.Count(e => e.EmpresaId == id) > 0;
        }
    }
}