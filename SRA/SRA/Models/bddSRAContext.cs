using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SRA.Models
{
    public class bddSRAContext : DbContext
    {
        public bddSRAContext() : base("bddSRA")
        {

        }
        public DbSet<TypeAnimal> TypeAnimals { get; set; }
    }
}