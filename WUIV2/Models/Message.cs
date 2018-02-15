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
        public String titre { get; set; }
        public String contenu { get; set; }
        public virtual Utilisateur expediteur { get; set; }
        public virtual AvisDeRecherche avisDeRecherche { get; set; }
        public int? messageParentId { get; set; }
        public virtual Message messageParent { get; set; }

        public Message()
        {

        }
    }
}