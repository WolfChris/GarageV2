namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

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
                new Models.Member { FirstName = "Bill", LastName = "Hickock" },
                new Models.Member { FirstName = "John", LastName = "Alkas Yousef" },
                new Models.Member { FirstName = "Chris", LastName = "Wolf" },
                new Models.Member { FirstName = "Petra", LastName = "Lindell" },
                new Models.Member { FirstName = "Joe", LastName = "Blow"}
            };

            context.Member.AddOrUpdate(m => new { m.FirstName, m.LastName }, members);
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
                new Models.ParkedVehicle {
                    RegNo = "ABC123",
                    Brand = "Volvo",
                    Model = "101",
                    Color = "Vit",
                    NumberOfWheels = 3,
                    VehicleTypeId = vehicleTypes[0].Id,
                    MemberId = members[0].Id,
                    CheckInTime = new DateTime(2017, 11, 2, 8, 30, 52)
                },
                new Models.ParkedVehicle
                {
                    RegNo = "AWS111",
                    Brand = "Concorde",
                    Model = "740",
                    Color = "Red",
                    NumberOfWheels = 4,
                    VehicleTypeId = vehicleTypes[2].Id,
                    MemberId = members[1].Id,
                    CheckInTime = new DateTime(2017, 11, 2, 8, 30, 52)
                },
                new Models.ParkedVehicle
                {
                    RegNo = "CDE123",
                    Brand = "Volvo",
                    Model = "9900",
                    Color = "Vit",
                    NumberOfWheels = 6,
                    VehicleTypeId = vehicleTypes[1].Id,
                    MemberId = members[2].Id,
                    CheckInTime = new DateTime(2017, 11, 3, 10, 14, 00)
                },
                new Models.ParkedVehicle
                {
                    RegNo = "EFG123",
                    Brand = "Yamaha",
                    Model = "YS125",
                    Color = "Röd",
                    NumberOfWheels = 2,
                    VehicleTypeId = vehicleTypes[4].Id,
                    MemberId = members[3].Id,
                    CheckInTime = DateTime.Now
                },
                new Models.ParkedVehicle
                {
                    RegNo = "CDE456",
                    Brand = "Yamarin",
                    Model = "Cross 60 Cabin ",
                    Color = "Grå",
                    NumberOfWheels = 0,
                    VehicleTypeId = vehicleTypes[3].Id,
                    MemberId = members[4].Id,
                    CheckInTime = new DateTime(2016, 10, 30, 9, 35, 00)
                }
            );

            context.Garage.AddOrUpdate(
                g => new { g.Capacity, g.PricePerHour },
                new Models.Garage { Capacity = 10, PricePerHour = 13.5 }
            );
        }
    }
}
