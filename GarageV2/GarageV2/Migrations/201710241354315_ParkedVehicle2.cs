namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicle2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "CheckInTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ParkedVehicles", "CheckOutTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ParkedVehicles", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "TotalPrice");
            DropColumn("dbo.ParkedVehicles", "CheckOutTime");
            DropColumn("dbo.ParkedVehicles", "CheckInTime");
        }
    }
}
