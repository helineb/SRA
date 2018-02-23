using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WUIV2.Models
{
    public class AvisDeRecherche
    {
        [Key]
        public int id { get; set; }
        public String titre { get; set; }
        public virtual Utilisateur membre { get; set; }

        [DataType(DataType.MultilineText)]
        public String description { get; set; }
        public virtual Animal animal { get; set; }
        public virtual Emplacement emplacement { get; set; }

        public List<Signalement> signalements { get; set; }

        public AvisDeRecherche()
        {

        }
    }
}