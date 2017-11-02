namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMemberVehicleType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ParkedVehicles", "MemberId", c => c.Int(nullable: false));
            AddColumn("dbo.ParkedVehicles", "Type_Id", c => c.Int());
            CreateIndex("dbo.ParkedVehicles", "Type_Id");
            AddForeignKey("dbo.ParkedVehicles", "Type_Id", "dbo.VehicleTypes", "Id");
            DropColumn("dbo.ParkedVehicles", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "Type", c => c.Int());
            DropForeignKey("dbo.ParkedVehicles", "Type_Id", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "Type_Id" });
            DropColumn("dbo.ParkedVehicles", "Type_Id");
            DropColumn("dbo.ParkedVehicles", "MemberId");
            DropTable("dbo.VehicleTypes");
        }
    }
}
