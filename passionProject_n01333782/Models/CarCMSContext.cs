using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

using System.Data.Entity.Infrastructure;

namespace passionProject_n01333782.Models
{
    public class CarCMSContext : DbContext
    {
        public CarCMSContext()
        {

        }

        public DbSet<CarMake> car_Makes { get; set; }
        public DbSet<CarManufactures> car_Manufactures { get; set; }
    }
}