using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebEstacionamentoTcc20.Data.Repositories.Implementation;
using WebEstacionamentoTcc20.Models;
using static WebEstacionamentoTcc20.Models.Empresa;
using AutoMapper;
using System;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace WebEstacionamentoTcc20.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly EmpresaRepository _empresasRepository;

        private ControleContext db = new ControleContext();

       public  string idsuario;

        public int Iduser;
        public string Idusers;


        GrupoAcesso grupoacesso = new GrupoAcesso();



        public EmpresasController()
        {
            this._empresasRepository = new EmpresaRepository(new Data.Repositories.UO.UnitOfWork());
        }



        // GET: Empresas
        public ActionResult Index(string idusuario)
        {

            var usuariologado = User.Identity.GetUserId();
          //  ViewBag.idusuario = idusuario; testadadada pdaodoaodahnlçakdocomcoemcaoadadadas



            List<Empresa> lista = new List<Empresa>();
            try {
               

             lista = _empresasRepository.PesquisarPorUsuario(usuariologado.Trim()).ToList();

                var modelo = Mapper.Map<List<Empresa>, List<EmpresaDisplayViewModel>>(lista);
         

            }
            catch
            {

                var modelo = Mapper.Map<List<Empresa>, List<EmpresaDisplayViewModel>>(_empresasRepository.GetAll().ToList());
                
            }



            var modelolista = Mapper.Map<List<Empresa>, List<EmpresaDisplayViewModel>>(lista);
            return View(modelolista);
        }
        


  

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create(string idusuario)
        {
            ViewBag.idusuario = idusuario;
      
            return View();
           
        }

        // POST: Empresas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaId,RazaoSocial,NomeFantasia,Cpf,Cnpj,Data_Cadastro,Endereco,Cidade,UF,CEP,Latitude,Longitude,NVagas,NDispo,Valor,Horafi,Horai,Seg,TER,Qua,Qui,Sex,Sab,Dom")] Empresa empresa)
        {
          


            if (ModelState.IsValid)
            {
                db.Empresas.Add(empresa);
                db.SaveChanges();
                var userId = User.Identity.GetUserId();
             ///    int lista = _empresasRepository.PesquisarPorUsuariologin(userId.Trim());
          

                
                grupoacesso.EmpresaId = empresa.EmpresaId;

               
             grupoacesso.id = userId;

              
                db.GrupoAcessoes.Add(grupoacesso);
                db.SaveChanges();

                
                return RedirectToAction("Index", "Empresas", new { idusuario = Iduser });

               
            }



           
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaId,RazaoSocial,NomeFantasia,Cpf,Cnpj,Data_Cadastro,Endereco,Cidade,UF,CEP,Latitude,Longitude,NVagas,NDispo,Valor,Horafi,Horai,Seg,TER,Qua,Qui,Sex,Sab,Dom")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }



        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
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
            List<Empresa> lista = new List<Empresa>();
            switch (searchBy)
            {
                case "Local":
                    lista = _empresasRepository.PesquisarPorLocal(search.Trim()).ToList();
                    break;
                default:
                    lista = _empresasRepository.GetAll().OrderBy(u => u.EmpresaId).ToList();
                    break;
            }
            var modelo = Mapper.Map<List<Empresa>, List<EmpresaDisplayViewModel>>(lista);
            return PartialView("_List", modelo);
        }
    }
}
