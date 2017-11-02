namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTypeToStringInParkedVEhicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "TypeId" });
            AddColumn("dbo.ParkedVehicles", "VehicleType_Id", c => c.Int());
            CreateIndex("dbo.ParkedVehicles", "VehicleType_Id");
            AddForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "VehicleType_Id" });
            DropColumn("dbo.ParkedVehicles", "VehicleType_Id");
            CreateIndex("dbo.ParkedVehicles", "TypeId");
            AddForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes", "Id", cascadeDelete: true);
        }
    }
}
