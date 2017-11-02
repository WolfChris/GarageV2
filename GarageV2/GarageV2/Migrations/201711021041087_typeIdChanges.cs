namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeIdChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParkedVehicles", "Type_Id", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "Type_Id" });
            RenameColumn(table: "dbo.ParkedVehicles", name: "Type_Id", newName: "TypeId");
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberNo = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.ParkedVehicles", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParkedVehicles", "TypeId");
            AddForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "TypeId" });
            AlterColumn("dbo.ParkedVehicles", "TypeId", c => c.Int());
            DropTable("dbo.Members");
            RenameColumn(table: "dbo.ParkedVehicles", name: "TypeId", newName: "Type_Id");
            CreateIndex("dbo.ParkedVehicles", "Type_Id");
            AddForeignKey("dbo.ParkedVehicles", "Type_Id", "dbo.VehicleTypes", "Id");
        }
    }
}
