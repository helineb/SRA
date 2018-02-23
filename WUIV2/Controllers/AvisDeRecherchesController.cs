using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WUIV2.Models;
using WUIV2.Models.DAL;
using WUIV2.Models.ViewModel;

namespace WUIV2.Controllers
{
    public class AvisDeRecherchesController : Controller
    {
        private AnimalContext db = new AnimalContext();

        // GET: AvisDeRecherches
        public ActionResult Index()
        {
            ViewBag.Title = "Les avis de recherche";
            return View(db.AvisDeRecherches.ToList());
        }

        // GET: AvisDeRecherches
        [Authorize(Roles = "MEMBRE")]
        public ActionResult Mine()
        {
            ViewBag.Title = "Mes avis de recherche";
            return View("Index",AvisDeRechercheDAL.getInstance().getMine(User.Identity.Name));
        }

        // GET: AvisDeRecherches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisDeRecherche avisDeRecherche = AvisDeRechercheDAL.getInstance().getById((int)id);
            if (avisDeRecherche == null)
            {
                return HttpNotFound();
            }
            return View(avisDeRecherche);
        }

        // GET: AvisDeRecherches/Create
        [Authorize(Roles = "MEMBRE")]
        public ActionResult Create()
        {
            var adrViewModel = new VMAvisDeRecherche();
            ViewBag.animal = new SelectList(db.Animals, "Id", "Nom");

            return View(adrViewModel);
        }

        // POST: AvisDeRecherches/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "MEMBRE")]
        public ActionResult Create(VMAvisDeRecherche VMadr)
        {
            if (ModelState.IsValid)
            {
                Utilisateur userConnected = UtilisateurDAL.getInstance().getByMail(User.Identity.Name);
                VMadr.avisDeRecherche.membre = userConnected;

                db.AvisDeRecherches.Add(VMadr.avisDeRecherche);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(VMadr);
        }

        // GET: AvisDeRecherches/Edit/5
        [Authorize(Roles = "MEMBRE")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisDeRecherche avisDeRecherche = db.AvisDeRecherches.Find(id);

            if (avisDeRecherche == null)
            {
                return HttpNotFound();
            }

            var adrViewModel = new VMAvisDeRecherche();
            adrViewModel.avisDeRecherche = avisDeRecherche;
            ViewBag.animal = new SelectList(db.Animals, "Id", "Nom");
            return View(adrViewModel);
        }

        // POST: AvisDeRecherches/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "MEMBRE")]
        public ActionResult Edit(VMAvisDeRecherche VMadr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VMadr.avisDeRecherche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(VMadr);
        }

        // GET: AvisDeRecherches/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AvisDeRecherche avisDeRecherche = db.AvisDeRecherches.Find(id);
            if (avisDeRecherche == null)
            {
                return HttpNotFound();
            }
            return View(avisDeRecherche);
        }

        // POST: AvisDeRecherches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            AvisDeRecherche avisDeRecherche = db.AvisDeRecherches.Find(id);
            db.AvisDeRecherches.Remove(avisDeRecherche);
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
