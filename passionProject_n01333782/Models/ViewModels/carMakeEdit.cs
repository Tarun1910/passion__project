using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProject_n01333782.Models.ViewModels
{
    public class carMakeEdit
    {
        public carMakeEdit()
        {

        }
         public virtual CarMake carMake { get; set; }

        public IEnumerable<CarManufactures>carManufactures { get; set; }

    }
}