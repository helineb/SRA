using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WUIV2.Models
{
    public class TypeAnimal
    {

        [Key]
        public int Id { get; set; }

        public float libelle { get; set; }

        public float description { get; set; }

        public virtual List<Animal> animals { get; set; }

        public TypeAnimal()
        {

        }


    }
}