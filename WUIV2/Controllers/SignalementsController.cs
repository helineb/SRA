using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WUIV2.Models;

namespace WUIV2.Controllers
{
    public class SignalementsController : Controller
    {
        private AnimalContext db = new AnimalContext();

        // GET: Signalements
        public ActionResult Index()
        {
            return View(db.Signalements.ToList());
        }

        // GET: Signalements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signalement signalement = db.Signalements.Find(id);
            if (signalement == null)
            {
                return HttpNotFound();
            }
            return View(signalement);
        }

        // GET: Signalements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signalements/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,commentaire")] Signalement signalement)
        {
            if (ModelState.IsValid)
            {
                db.Signalements.Add(signalement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(signalement);
        }

        // GET: Signalements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signalement signalement = db.Signalements.Find(id);
            if (signalement == null)
            {
                return HttpNotFound();
            }
            return View(signalement);
        }

        // POST: Signalements/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,commentaire")] Signalement signalement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signalement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signalement);
        }

        // GET: Signalements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signalement signalement = db.Signalements.Find(id);
            if (signalement == null)
            {
                return HttpNotFound();
            }
            return View(signalement);
        }

        // POST: Signalements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Signalement signalement = db.Signalements.Find(id);
            db.Signalements.Remove(signalement);
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
