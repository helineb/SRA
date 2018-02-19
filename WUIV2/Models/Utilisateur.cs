using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WUIV2.Models
{
    public class Utilisateur
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Email")]
        public String mail { get; set; }
        [Display(Name = "Mot de passe")]
        public String mdp { get; set; }
        [Display(Name = "Rôle")]
        public String role { get; set; }
        public virtual List<Message> messages { get; set; }

        public Utilisateur()
        {

        }

        public bool IsAdministrateur()
        {
            if(this.role == "ADMINISTRATEUR")
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool IsMembre()
        {
            if (this.role == "MEMBRE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}