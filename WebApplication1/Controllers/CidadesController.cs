using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace CadeMedico.Controllers
{
    public class CidadesController : Controller
    {

        private UsuariosContext db = new UsuariosContext();

        // GET: Cidades
        public ActionResult Index(){
            return View(db.Cidades.ToList());
        }



        // GET: Cidades/Create
        [Authorize]
        public ActionResult Create() {
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "CidadeID,Nome")] Cidade cidade) {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        // GET: Cidades/Edit/5
        [Authorize]
        public ActionResult Edit(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "CidadeID,Nome")] Cidade cidade) {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        [Authorize]
        public ActionResult Delete(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = db.Cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id) {
            Cidade cidade = db.Cidades.Find(id);
            db.Cidades.Remove(cidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
