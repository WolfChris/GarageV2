namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VrhicleType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "VehicleType_Id" });
            RenameColumn(table: "dbo.ParkedVehicles", name: "VehicleType_Id", newName: "VehicleTypeId");
            AddColumn("dbo.VehicleTypes", "Name", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "VehicleTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParkedVehicles", "VehicleTypeId");
            AddForeignKey("dbo.ParkedVehicles", "VehicleTypeId", "dbo.VehicleTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.ParkedVehicles", "TypeId");
            DropColumn("dbo.VehicleTypes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleTypes", "Type", c => c.String());
            AddColumn("dbo.ParkedVehicles", "TypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ParkedVehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "VehicleTypeId" });
            AlterColumn("dbo.ParkedVehicles", "VehicleTypeId", c => c.Int());
            DropColumn("dbo.VehicleTypes", "Name");
            RenameColumn(table: "dbo.ParkedVehicles", name: "VehicleTypeId", newName: "VehicleType_Id");
            CreateIndex("dbo.ParkedVehicles", "VehicleType_Id");
            AddForeignKey("dbo.ParkedVehicles", "VehicleType_Id", "dbo.VehicleTypes", "Id");
        }
    }
}
