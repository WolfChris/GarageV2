namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageV2.DataAccessLayer.ParkedVehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarageV2.DataAccessLayer.ParkedVehicleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ParkedVehicle.AddOrUpdate(
                p => p.RegNo,
                new ParkedVehicle { RegNo = "ABC123" },
                new ParkedVehicle { RegNo = "CDE123" },
                new ParkedVehicle { RegNo = "ABC456" },
                new ParkedVehicle { RegNo = "CDE456" }
            );
        }
    }
}
