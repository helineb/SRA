﻿using System;
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

        [Display(Name = "Espèce")]
        public String libelle { get; set; }

        [Display(Name = "Description")]
        public String description { get; set; }

        public virtual List<Animal> animals { get; set; }

        public TypeAnimal()
        {

        }


    }
}