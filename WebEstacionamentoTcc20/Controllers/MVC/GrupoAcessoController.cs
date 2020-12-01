using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEstacionamentoTcc20.Models;

namespace WebEstacionamentoTcc20.Controllers.MVC
{
    public class GrupoAcessoController : Controller
    {
        private ControleContext db = new ControleContext();

        // GET: GrupoAcesso
        public ActionResult Index()
        {
            var grupoAcessoes = db.GrupoAcessoes.Include(g => g.id);
            return View(grupoAcessoes.ToList());
        }

        // GET: GrupoAcesso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoAcesso grupoAcesso = db.GrupoAcessoes.Find(id);
            if (grupoAcesso == null)
            {
                return HttpNotFound();
            }
            return View(grupoAcesso);
        }

        // GET: GrupoAcesso/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName");
            return View();
        }

        // POST: GrupoAcesso/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrupoAcessoId,UserId,EmpresaId")] GrupoAcesso grupoAcesso)
        {
            if (ModelState.IsValid)
            {
                db.GrupoAcessoes.Add(grupoAcesso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", grupoAcesso.id);
            return View(grupoAcesso);
        }

        // GET: GrupoAcesso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoAcesso grupoAcesso = db.GrupoAcessoes.Find(id);
            if (grupoAcesso == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", grupoAcesso.id);
            return View(grupoAcesso);
        }

        // POST: GrupoAcesso/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrupoAcessoId,UserId,EmpresaId")] GrupoAcesso grupoAcesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoAcesso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Usuarios, "UserId", "UserName", grupoAcesso.id);
            return View(grupoAcesso);
        }

        // GET: GrupoAcesso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoAcesso grupoAcesso = db.GrupoAcessoes.Find(id);
            if (grupoAcesso == null)
            {
                return HttpNotFound();
            }
            return View(grupoAcesso);
        }

        // POST: GrupoAcesso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoAcesso grupoAcesso = db.GrupoAcessoes.Find(id);
            db.GrupoAcessoes.Remove(grupoAcesso);
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
    }
}
