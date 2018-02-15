using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SRA.Models
{
    public class TypeAnimal
    {
        [Key]
        public Guid id { get; set; }
        public String libelle { get; set; }
        public String description { get; set; }
    }
}