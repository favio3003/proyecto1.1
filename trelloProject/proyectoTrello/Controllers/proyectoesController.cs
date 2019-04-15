using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyectoTrello.Models;

namespace proyectoTrello.Controllers
{
    public class proyectoesController : Controller
    {
        private proyectoTrelloEntities db = new proyectoTrelloEntities();

        // GET: proyectoes
        public ActionResult Index()
        {
            var proyectoes = db.proyectoes.Include(p => p.usuario);
            return View(proyectoes.ToList());
        }

        // GET: proyectoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyectoes.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: proyectoes/Create
        public ActionResult Create()
        {
            ViewBag.idResponsable = new SelectList(db.usuarios, "idUsuario", "NombreCompleto");
            return View();
        }

        // POST: proyectoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProyecto,Sigla,Nombre,Descripcion,Imagen,Estado,idResponsable")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.proyectoes.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idResponsable = new SelectList(db.usuarios, "idUsuario", "NombreCompleto", proyecto.idResponsable);
            return View(proyecto);
        }

        // GET: proyectoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyectoes.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idResponsable = new SelectList(db.usuarios, "idUsuario", "NombreCompleto", proyecto.idResponsable);
            return View(proyecto);
        }

        // POST: proyectoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProyecto,Sigla,Nombre,Descripcion,Imagen,Estado,idResponsable")] proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idResponsable = new SelectList(db.usuarios, "idUsuario", "NombreCompleto", proyecto.idResponsable);
            return View(proyecto);
        }

        // GET: proyectoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyecto proyecto = db.proyectoes.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proyecto proyecto = db.proyectoes.Find(id);
            db.proyectoes.Remove(proyecto);
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
