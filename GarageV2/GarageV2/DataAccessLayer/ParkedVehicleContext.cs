﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageV2.DataAccessLayer
{
    public class ParkedVehicleContext : DbContext
    {
        public DbSet<Models.ParkedVehicle> ParkedVehicle { get; set; }
        public DbSet<Models.Garage> Garage { get; set; }
        public DbSet<Models.VehicleType> VehicleType { get; set; }
        public DbSet<Models.Member> Member { get; set; }

        public ParkedVehicleContext() : base("GarageV2Connection")
        {

        }
    }
}