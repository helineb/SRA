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
        public virtual Emplacement emplacement { get; set; }
        public virtual Utilisateur utilisateur { get; set; }
        public String commentaire { get; set; }

        public Signalement()
        {

        }
    }
}