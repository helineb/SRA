using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WUIV2.Models.ViewModel
{
    public class VMUtilisateurPassword
    {

        public Utilisateur utilisateur { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType("Password")]
        public String Password { get; set; }

        [Required]
        [Display(Name = "Confirmer le mot de passe")]
        [DataType("Password")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public String ConfirmPassword { get; set; }

        public VMUtilisateurPassword()
        {
            this.utilisateur = new Utilisateur();
        }

        public VMUtilisateurPassword(Utilisateur utilisateur)
        {
            this.utilisateur = utilisateur;
        }

    }
}