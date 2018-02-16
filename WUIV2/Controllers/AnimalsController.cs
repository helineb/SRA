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
    public class AnimalsController : Controller
    {
        private AnimalContext db = new AnimalContext();

        // GET: Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.proprietaire).Include(a => a.typeAnimal);
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.proprietaireId = new SelectList(db.Utilisateurs, "id", "mail");
            ViewBag.typeAnimalId = new SelectList(db.TypeAnimals, "Id", "Id");
            return View();
        }

        // POST: Animals/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,proprietaireId,description,age,tatouage,puce,vaccin,castre,typeAnimalId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proprietaireId = new SelectList(db.Utilisateurs, "id", "mail", animal.proprietaireId);
            ViewBag.typeAnimalId = new SelectList(db.TypeAnimals, "Id", "Id", animal.typeAnimalId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.proprietaireId = new SelectList(db.Utilisateurs, "id", "mail", animal.proprietaireId);
            ViewBag.typeAnimalId = new SelectList(db.TypeAnimals, "Id", "Id", animal.typeAnimalId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,proprietaireId,description,age,tatouage,puce,vaccin,castre,typeAnimalId")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proprietaireId = new SelectList(db.Utilisateurs, "id", "mail", animal.proprietaireId);
            ViewBag.typeAnimalId = new SelectList(db.TypeAnimals, "Id", "Id", animal.typeAnimalId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
