﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WUIV2.Models;
using WUIV2.Models.DAL;

namespace WUIV2.Controllers
{
    public class UtilisateursController : Controller
    {

        // GET: Utilisateurs
        [Authorize]
        public ActionResult Index()
        {
            return View(UtilisateurDAL.getAll());
        }

        [Authorize]
        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = UtilisateurDAL.getById((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,mail,mdp,role")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                Utilisateur u = UtilisateurDAL.create(utilisateur);
                return RedirectToAction("Index");
            }

            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = UtilisateurDAL.getById((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "id,mail,mdp,role")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                Utilisateur u = UtilisateurDAL.update(utilisateur);
                return RedirectToAction("Index");
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = UtilisateurDAL.getById((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            UtilisateurDAL.delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UtilisateurDAL.Dispose();
            }
            base.Dispose(disposing);
        }




        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String mail,String mdp)
        {
            Utilisateur AuthenticatedUser = UtilisateurDAL.authenticate(mail, mdp);
            
            try
            {
                int id = AuthenticatedUser.id;
                FormsAuthentication.SetAuthCookie(AuthenticatedUser.id.ToString(), false);
                return RedirectToAction("Details", new { id = id });
            }
            catch(NullReferenceException e)
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        public ActionResult Disconnect()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
