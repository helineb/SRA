using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WUIV2.Models.DAL
{
    public static class UtilisateurDAL
    {
        private static AnimalContext db = new AnimalContext();

        //create
        public static Utilisateur create(Utilisateur utilisateur)
        {
            db.Utilisateurs.Add(utilisateur);
            db.SaveChanges();
            return utilisateur;
        }

        //update
        public static Utilisateur update(Utilisateur utilisateur)
        {
            db.Entry(utilisateur).State = EntityState.Modified;
            db.SaveChanges();
            return utilisateur;
        }

        //getAll 
        public static List<Utilisateur> getAll()
        {
            return db.Utilisateurs.ToList() ;
        }

        //getById
        public static Utilisateur getById(int id)
        {
            return db.Utilisateurs.Find(id) ;
        }

        //authentified
        public static Utilisateur authenticate(string mail, string mdp)
        {
            return db.Utilisateurs.FirstOrDefault(u => u.mail == mail && u.mdp == mdp) ;
        }

        //delete
        public static void delete(int id)
        {
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateur);
            db.SaveChanges();
        }

        public static void Dispose()
        {
              db.Dispose();
        }
    }
}