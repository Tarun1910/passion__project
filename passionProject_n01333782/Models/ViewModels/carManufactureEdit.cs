using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionProject_n01333782.Models.ViewModels
{
	public class carManufactureEdit
	{
	    public carManufactureEdit()
        {

        }
		public virtual CarManufactures Manufactures { get; set; }

		public IEnumerable<CarMake> carMakes { get; set; }

	}
}