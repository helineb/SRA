﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WUIV2.Models;
using WUIV2.Models.DAL;
using WUIV2.Models.ViewModel;

namespace WUIV2.Controllers
{
    public class UtilisateursController : Controller
    {

        // GET: Utilisateurs
        [Authorize(Roles= "ADMINISTRATEUR")]
        public ActionResult Index()
        {
            return View(UtilisateurDAL.getInstance().getAll());
        }

        [Authorize]
        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = UtilisateurDAL.getInstance().getById((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        [Authorize]
        // GET: Utilisateurs/Details/mail
        public ActionResult Mine()
        {
            String mail = User.Identity.Name;
            Utilisateur utilisateur = UtilisateurDAL.getInstance().getByMail(mail);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View("details",utilisateur);
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
                Utilisateur u = UtilisateurDAL.getInstance().create(utilisateur);
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
            Utilisateur utilisateur = UtilisateurDAL.getInstance().getById((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }

            var VMUser = new VMUtilisateurPassword(utilisateur);

            return View(VMUser);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMUtilisateurPassword VMUser)
        {
            if (ModelState.IsValid)
            {
                VMUser.utilisateur.mdp = VMUser.Password;
                Utilisateur u = UtilisateurDAL.getInstance().update(VMUser.utilisateur);
                return RedirectToAction("Index");
            }
            return View(VMUser);
        }

        // GET: Utilisateurs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = UtilisateurDAL.getInstance().getById((int)id);
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
            UtilisateurDAL.getInstance().delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UtilisateurDAL.getInstance().Dispose();
            }
            base.Dispose(disposing);
        }




        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String mail,String mdp, String returnUrl)
        {
            Utilisateur AuthenticatedUser = UtilisateurDAL.getInstance().authenticate(mail, mdp);
            
            if(AuthenticatedUser != null)
            {
                int id = AuthenticatedUser.id;
                FormsAuthentication.SetAuthCookie(AuthenticatedUser.mail.ToString(), false);
                
                var authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    string encTicket = authCookie.Value;
                    if (!String.IsNullOrEmpty(encTicket))
                    {
                        var ticket = FormsAuthentication.Decrypt(encTicket);
                        var user = new UserIdentity(ticket);
                        var role = Roles.GetRolesForUser(user.Name);
                        var prin = new GenericPrincipal(user, role);
                        HttpContext.User = prin;
                    }
                }

               if(String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "AvisDeRecherches");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [Authorize]
        public ActionResult Disconnect()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "AvisDeRecherches");
        }
        
    }
}
