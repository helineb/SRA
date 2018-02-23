using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WUIV2.Models
{
    public class Signalement
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Emplacement")]
        public virtual Emplacement emplacement { get; set; }

        [Display(Name = "Avis de recherche")]
        public virtual AvisDeRecherche avisDeRecherche { get; set; }

        [Display(Name = "Utilisateur")]
        public virtual Utilisateur utilisateur { get; set; }

        [Display(Name = "Commentaire")]
        [DataType(DataType.MultilineText)]
        public String commentaire { get; set; }

        [Display(Name = "Adresse")]
        public String adresse { get; set; }

        [Display(Name = "Ville")]
        public String ville { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime dateSignalement { get; set; }

        public Signalement()
        {

        }
    }
}