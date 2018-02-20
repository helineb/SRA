using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WUIV2.Models
{
    public class Message
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Titre")]
        public String titre { get; set; }

        [Display(Name = "Contenu")]
        public String contenu { get; set; }

        [Display(Name = "Expediteur")]
        public virtual Utilisateur expediteur { get; set; }

        [Display(Name = "Avis de recherche")]
        public virtual AvisDeRecherche avisDeRecherche { get; set; }

        [Display(Name = "Message précédent")]
        public int? messageParentId { get; set; }

        [Display(Name = "Message précédent")]
        public virtual Message messageParent { get; set; }

        public Message()
        {

        }
    }
}