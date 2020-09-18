using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmParcialPractica.Models;

namespace AdmParcialPractica.Controllers
{
    public class ValverdesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Valverdes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Valverdes.ToList());
        }

        // GET: Valverdes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valverde valverde = db.Valverdes.Find(id);
            if (valverde == null)
            {
                return HttpNotFound();
            }
            return View(valverde);
        }

        // GET: Valverdes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Valverdes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValverdeID,FriendofValverde,Place,Email,Birthdate")] Valverde valverde)
        {
            if (ModelState.IsValid)
            {
                db.Valverdes.Add(valverde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valverde);
        }

        // GET: Valverdes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valverde valverde = db.Valverdes.Find(id);
            if (valverde == null)
            {
                return HttpNotFound();
            }
            return View(valverde);
        }

        // POST: Valverdes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValverdeID,FriendofValverde,Place,Email,Birthdate")] Valverde valverde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valverde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valverde);
        }

        // GET: Valverdes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valverde valverde = db.Valverdes.Find(id);
            if (valverde == null)
            {
                return HttpNotFound();
            }
            return View(valverde);
        }

        // POST: Valverdes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valverde valverde = db.Valverdes.Find(id);
            db.Valverdes.Remove(valverde);
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
