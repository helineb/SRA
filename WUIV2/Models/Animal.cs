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

        [Display(Name = "Nom")]
        public String nom { get; set; }

        public int? proprietaireId { get; set; }

        public virtual Utilisateur proprietaire { get; set; }

        [Display(Name = "Description")]
        public String description { get; set; }

        [Display(Name = "Âge")]
        public int age { get; set; }

        [Display(Name = "Tatoué(e)")]
        public Boolean tatouage { get; set; }

        [Display(Name = "Pucé(e)")]
        public Boolean puce { get; set; }

        [Display(Name = "Vacciné(e)")]
        public Boolean vaccin { get; set; }

        [Display(Name = "Castré(e)")]
        public Boolean castre { get; set; }

        public int? typeAnimalId { get; set; }

        [Display(Name = "Espèce")]
        public TypeAnimal typeAnimal { get; set; }

        public Animal()
        {

        }
    }
}