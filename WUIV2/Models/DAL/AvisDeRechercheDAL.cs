using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WUIV2.Models.DAL
{
    public class AvisDeRechercheDAL
    {
        private AnimalContext db ;


        public static AvisDeRechercheDAL getInstance()
        {
            return new AvisDeRechercheDAL();
        }

        public AvisDeRechercheDAL()
        {
            this.db = new AnimalContext();
        }

        //create
        public AvisDeRecherche create(AvisDeRecherche adr)
        {
            db.AvisDeRecherches.Add(adr);
            db.SaveChanges();
            return adr;
        }

        //update
        public AvisDeRecherche update(AvisDeRecherche adr)
        {
            db.Entry(adr).State = EntityState.Modified;
            db.SaveChanges();
            return adr;
        }

        //getAll 
        public List<AvisDeRecherche> getAll()
        {
            return db.AvisDeRecherches.ToList() ;
        }

        //getById
        public AvisDeRecherche getById(int id)
        {
            return db.AvisDeRecherches.Find(id) ;
        }

        //getMine
        public List<AvisDeRecherche> getMine(string mail)
        {

            var listMine = new List<AvisDeRecherche>();
            string query = "SELECT * FROM AvisDeRecherche adr INNER JOIN Utilisateur u ON u.id=adr.membre_id AND u.mail = @p0";
            listMine = db.AvisDeRecherches.SqlQuery(query, mail).ToList();

            return listMine;
        }


        //delete
        public void delete(int id)
        {
            AvisDeRecherche adr = db.AvisDeRecherches.Find(id);
            db.AvisDeRecherches.Remove(adr);
            db.SaveChanges();
        }

        public void Dispose()
        {
              db.Dispose();
        }
    }
}