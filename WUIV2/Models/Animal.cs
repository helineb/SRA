using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WUIV2.Models
{
    public class Animal
    {
        [Key]
        public int id { get; set; }
        public String nom { get; set; }
        public int? proprietaireId { get; set; }
        public virtual Utilisateur proprietaire { get; set; }
        public String description { get; set; }
        public int age { get; set; }
        public Boolean tatouage { get; set; }
        public Boolean puce { get; set; }
        public Boolean vaccin { get; set; }
        public Boolean castre { get; set; }
        public int? typeAnimalId { get; set; }
        public TypeAnimal typeAnimal { get; set; }

        public Animal()
        {

        }
    }
}