using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GarageV2.Models;

namespace GarageV2.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public DbSet<Garage<ParkedVehicle>> Garage { get; set; }

        public GarageContext() : base("GarageV2Connection")
        {

        }
    
    }
}