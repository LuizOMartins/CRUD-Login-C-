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
    public class MedicosController : Controller
    {
        private UsuariosContext db = new UsuariosContext();

        // GET: Medicos
        public ActionResult Index() {
            var medicos = db.Medicos.Include(m => m.Cidade).Include(m => m.Especialidade);
            return View(medicos.ToList());
        }

        // GET: Medicos/Create
        [Authorize]
        public ActionResult Create() {
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome");
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "MedicoID,Nome,CRM,Endereco,Telefone,CidadeID,EspecialidadeID")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome", medico.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // GET: Medicos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id){
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome", medico.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "MedicoID,Nome,CRM,Endereco,Telefone,CidadeID,EspecialidadeID")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "Nome", medico.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "EspecialidadeID", "Nome", medico.EspecialidadeID);
            return View(medico);
        }

        // GET: Medicos/Delete/5
        [Authorize]
        public ActionResult Delete(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
