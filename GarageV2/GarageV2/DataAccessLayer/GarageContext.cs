using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageV2.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public DbSet<Models.ParkedVehicle> ParkedVehicle { get; set; }

        public GarageContext() : base("GarageV2Connection")
        {

        }
    }
}