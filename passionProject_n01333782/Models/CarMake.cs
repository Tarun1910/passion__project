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
        public int ModelID { get; set; }
        [Required, StringLength(99), Display(Name = "Model Name")]
        public string ModelName { get; set; }

        [Required, StringLength(99), Display(Name = "Model year")]
        public string ModelYear { get; set; }

        [Required, StringLength(255), Display(Name = "Description")]
        public string Description { get; set; }
        
        public virtual CarManufactures CarManufactures { get; set; }
        

    }
}