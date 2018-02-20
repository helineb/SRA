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

        [Display(Name = "Utilisateur")]
        public virtual Utilisateur utilisateur { get; set; }

        [Display(Name = "Commentaire")]
        public String commentaire { get; set; }

        public Signalement()
        {

        }
    }
}