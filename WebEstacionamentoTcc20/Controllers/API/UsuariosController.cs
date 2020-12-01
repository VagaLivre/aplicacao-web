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

    [RoutePrefix("API/Usuarios")]
    public class UsuariosController : ApiController
    {
        

        private ControleContext db = new ControleContext();

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(JObject form)
        {
            string email = string.Empty;
            string password = string.Empty;
            dynamic jsonObject = form;

            try
            {
                email = jsonObject.Email.Value;
                password = jsonObject.Senha.Value;
            }
            catch
            {
                return this.BadRequest("Chamada Innnnnncorretaa");
            }

            var userContext = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.Find(email, password);

            if (userASP == null)
            {
                return this.BadRequest("Usuário ou Senha incorretossssss");
            }

            var user = db.Usuarios
                .Where(u => u.UserName == email)
                .FirstOrDefault();

            if (user == null)
            {
                return this.BadRequest("Usuário ou Senha incorretos sss");
            }

            return this.Ok(user);
        }



        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.UserId)
            {
                return BadRequest();
            }

            var db2 = new ControleContext();
            var oldUser = db2.Usuarios.Find(usuario.UserId);
            db2.Dispose();


            db.Entry(usuario).State = EntityState.Modified;

            try
            {

                db.SaveChanges();
                if (oldUser != null && oldUser.UserName != usuario.UserName)
                {
                    Utilidades.ChangeEmailUserASP(oldUser.UserName, usuario.UserName);
                }
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.Ok(usuario);
        }

        // POST: api/Usuarios
      
        public IHttpActionResult PostUsuario(UsuarioSenha UsuarioSenha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                Endereco = UsuarioSenha.Endereco,
                TipoUsuario = 1,
                Sobrenome = UsuarioSenha.Sobrenome,
                Telefone = UsuarioSenha.Telefone,
                UserName = UsuarioSenha.UserName

            };

            try
            {
               
                db.Usuarios.Add(UsuarioSenha);
                db.SaveChanges();
                Utilidades.CreateUserASP(UsuarioSenha.UserName, UsuarioSenha.senha);
               
            }
            catch(Exception EX )
            {
                ModelState.AddModelError(String.Empty, EX.Message);
            }

            UsuarioSenha.UserId = usuario.UserId;
            UsuarioSenha.TipoUsuario = 1;


            return this.Ok(UsuarioSenha);
        }
        
        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.UserId == id) > 0;
        }
    }
}