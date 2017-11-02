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
            var members = new[] {
            //context.Member.AddOrUpdate(
                //m => v.MemberNo,
                new Models.Member { FirstName = "Bill", LastName = "Hickock", MemberNo = 1 },
                new Models.Member { FirstName = "John", LastName = "Alkas Yousef", MemberNo = 2 },
                new Models.Member { FirstName = "Chris", LastName = "Wolf", MemberNo = 3 },
                new Models.Member { FirstName = "Petra", LastName = "Lindell", MemberNo = 4 },
                new Models.Member { FirstName = "Joe", LastName = "Blow", MemberNo = 5 }
            };

            context.Member.AddOrUpdate(m => new { m.FirstName, m.LastName, m.MemberNo }, members);
            context.SaveChanges();

            var vehicleTypes = new[]
            {
                new Models.VehicleType { Name = "Bil" },
                new Models.VehicleType { Name = "Buss" },
                new Models.VehicleType { Name = "Flygplan" },
                new Models.VehicleType { Name = "Båt" },
                new Models.VehicleType { Name = "Motorcykel" }
            };

            context.VehicleType.AddOrUpdate(v => new { v.Name }, vehicleTypes);
            context.SaveChanges();

            context.ParkedVehicle.AddOrUpdate(
                p => p.RegNo,
                new Models.ParkedVehicle { RegNo = "ABC123", VehicleTypeId = vehicleTypes[0].Id, MemberId = members[0].Id, CheckInTime=DateTime.Now.Add(new TimeSpan(-36,0,0))},
                new Models.ParkedVehicle { RegNo = "AWS111", VehicleTypeId = vehicleTypes[2].Id, MemberId = members[1].Id, CheckInTime = DateTime.Now.Add(new TimeSpan(-36, 0, 0)) },
                new Models.ParkedVehicle { RegNo = "CDE123", VehicleTypeId = vehicleTypes[1].Id, MemberId = members[2].Id, CheckInTime = DateTime.Now.Add(new TimeSpan(-1, -10, -25)) },
                new Models.ParkedVehicle { RegNo = "ABC456", VehicleTypeId = vehicleTypes[4].Id, MemberId = members[3].Id, CheckInTime = DateTime.Now.Add(new TimeSpan(0,-1, -59)) },
                new Models.ParkedVehicle { RegNo = "CDE456", VehicleTypeId = vehicleTypes[3].Id, MemberId = members[4].Id, CheckInTime = DateTime.Now }
            );

            context.Garage.AddOrUpdate(
                g => new { g.Capacity, g.PricePerHour },
                new Models.Garage { Capacity = 10, PricePerHour = 13.5 }
            );
        }
    }
}
