using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WUIV2.Models
{
    public class Emplacement
    {

        [Key]
        public int Id { get; set; }

        public float longitude { get; set; }

        public float latitude { get; set; }

        public Emplacement()
        {

        }


    }
}