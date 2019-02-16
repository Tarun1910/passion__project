using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace passionProject_n01333782.Models
{
    public class CarManufactures
    {
        [Key]
        public  int Name_id { get; set; }

        [Required, StringLength(99), Display(Name = "Manufacture Name")]
        public string CompanyName { get; set; }

        [Required, StringLength(99), Display(Name = "Est Year")]
        public string Year { get; set; }

      
    }
}