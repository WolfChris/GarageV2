namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GarageV2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageV2.DataAccessLayer.ParkedVehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarageV2.DataAccessLayer.ParkedVehicleContext context)
        {

            context.ParkedVehicle.AddOrUpdate(
                p => p.RegNo,
                new Models.ParkedVehicle { RegNo = "ABC123", CheckInTime=DateTime.Now.Add(new TimeSpan(-36,0,0))},
                new Models.ParkedVehicle { RegNo = "CDE123", CheckInTime = DateTime.Now.Add(new TimeSpan(-1, -10, -25)) },
                new Models.ParkedVehicle { RegNo = "ABC456", CheckInTime = DateTime.Now.Add(new TimeSpan(0,-1, -59)) },
                new Models.ParkedVehicle { RegNo = "CDE456", CheckInTime = DateTime.Now }
            );

            context.Garage.AddOrUpdate(
                g => new { g.Capacity, g.PricePerHour },
                new Models.Garage { Capacity = 10, PricePerHour = 13.5 }
            );
        }
    }
}
