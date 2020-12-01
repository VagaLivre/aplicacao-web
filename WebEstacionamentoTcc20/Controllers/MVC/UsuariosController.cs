using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEstacionamentoTcc20.Classes;
using WebEstacionamentoTcc20.Data.Repositories.Implementation;
using WebEstacionamentoTcc20.Models;
using static WebEstacionamentoTcc20.Models.Usuario;

namespace WebEstacionamentoTcc20.Controllers.MVC
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _usuariosRepository;
       

        private ControleContext db = new ControleContext();
        public int iduseremp;
        GrupoAcesso grupoacesso = new GrupoAcesso();

        public UsuariosController()
        {
            this._usuariosRepository = new UsuarioRepository(new Data.Repositories.UO.UnitOfWork());
        }



        // GET: Usuarios
        public ActionResult Index()
        {

            var usuariologado = User.Identity.GetUserId();
            //  ViewBag.idusuario = idusuario;



            List<Usuario> lista = new List<Usuario>();
        try
            {


                lista = _usuariosRepository.PesquisarUsuariosCadastrados(usuariologado.Trim()).ToList();

                var modelo = Mapper.Map<List<Usuario>, List<UsuarioDisplayViewModel>>(lista);


            }
            catch
            {

                //   var modelo = Mapper.Map<List<Empresa>, List<UsuarioDisplayViewModel>>(_usuariosRepository.GetAll().ToList());

                //   var modelo = Mapper.Map<List<Empresa>, List<UsuarioDisplayViewModel>>(_usuariosRepository.GetAll().ToList());

            }



            var modelolista = Mapper.Map<List<Usuario>, List<UsuarioDisplayViewModel>>(lista);
            return View(modelolista);


           
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create(string tipoUsuario)
        {
            ViewBag.TipoUsuario = tipoUsuario;
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioView view)
        {
            if (ModelState.IsValid)
            {


                view.Usuario.id = User.Identity.GetUserId();
                db.Usuarios.Add(view.Usuario);
                

                try
                {


                    if (view.Foto != null)
                {
                     var pic = Utilidades.UploadPhoto(view.Foto);
                        if (!string.IsNullOrEmpty(pic)){
                            view.Usuario.Photo = string.Format("~/Content/Fotos/{0}", pic);
                        }

                }
                    db.SaveChanges();



                    Utilidades.CreateUserASP(view.Usuario.UserName);

                    




                    if (view.Usuario.TipoUsuario == 1)
                    {
                        Utilidades.AddRoleToUser(view.Usuario.UserName, "UsuarioAplicativo");
                    }

                    if (view.Usuario.TipoUsuario == 2)
                    {
                        Utilidades.AddRoleToUser(view.Usuario.UserName, "UsuarioEstacionamento");
                    }

               //     grupoacesso.EmpresaId = empresa.EmpresaId;


                 //   grupoacesso.id = userId;


                 //   db.GrupoAcessoes.Add(grupoacesso);
                 //   db.SaveChanges();




                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }


                if (view.Usuario.TipoUsuario == 2)
                {
                    iduseremp = view.Usuario.UserId;
                    return RedirectToAction("Create", "Empresas", new { idusuario = iduseremp });

                }
                else
                {
                    return RedirectToAction("Index");
                }

            }




            return View(view);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Nome,Sobrenome,Telefone,Endereco,Photo,UsuarioApp,UsuarioEst")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Pesquisar(string searchBy, string search)
        {
            List<Usuario> lista = new List<Usuario>();
            switch (searchBy)
            {
                case "Local":
                    lista = _usuariosRepository.PesquisarPorLocal(search.Trim()).ToList();
                    break;
                default:
                    lista = _usuariosRepository.GetAll().OrderBy(u => u.UserId).ToList();
                    break;
            }
            var modelo = Mapper.Map<List<Usuario>, List<UsuarioDisplayViewModel>>(lista);
            return PartialView("_List", modelo);
        }
    }
}

