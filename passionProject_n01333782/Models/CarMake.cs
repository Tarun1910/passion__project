using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace passionProject_n01333782.Models
{
    public class CarMake    
    {
        [Key]
        [Required, StringLength(99), Display(Name = "Model Name")]
        public string ModelName { get; set; }

        [Required, StringLength(99), Display(Name = "Model Trim")]
        public string ModelYear { get; set; }

        [Required, StringLength(255), Display(Name = "Model Type")]
        public string Description { get; set; }

    }
}