using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WUIV2.Models.DAL
{
    public class UtilisateurDAL
    {
        private AnimalContext db ;


        public static UtilisateurDAL getInstance()
        {
            return new UtilisateurDAL();
        }

        public UtilisateurDAL()
        {
            this.db = new AnimalContext();
        }

        //create
        public Utilisateur create(Utilisateur utilisateur)
        {
            db.Utilisateurs.Add(utilisateur);
            db.SaveChanges();
            return utilisateur;
        }

        //update
        public Utilisateur update(Utilisateur utilisateur)
        {
            db.Entry(utilisateur).State = EntityState.Modified;
            db.SaveChanges();
            return utilisateur;
        }

        //getAll 
        public List<Utilisateur> getAll()
        {
            return db.Utilisateurs.ToList() ;
        }

        //getById
        public Utilisateur getById(int id)
        {
            return db.Utilisateurs.Find(id) ;
        }
        //getById
        public Utilisateur getByMail(string mail)
        {
            return db.Utilisateurs.FirstOrDefault(u => u.mail == mail);
        }

        //authentified
        public Utilisateur authenticate(string mail, string mdp)
        {
            return db.Utilisateurs.FirstOrDefault(u => u.mail == mail && u.mdp == mdp) ;
        }

        //delete
        public void delete(int id)
        {
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateur);
            db.SaveChanges();
        }

        public void Dispose()
        {
              db.Dispose();
        }
    }
}