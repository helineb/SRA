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
        public String mail { get; set; }
        public String mdp { get; set; }
        public Role role { get; set; }
        public virtual List<Message> messages { get; set; }

        public Utilisateur()
        {

        }
    }
}