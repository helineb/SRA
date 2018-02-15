using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WUIV2.Models
{
    public class AnimalContext : DbContext
    {

        public AnimalContext() : base("DefaultConnection")
        {
        }

        public DbSet<Emplacement> Emplacements { get; set; }
        public DbSet<TypeAnimal> TypeAnimals { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AvisDeRecherche> AvisDeRecherches { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Signalement> Signalements { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}