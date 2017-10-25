namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleTypeEnum2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.Int(nullable: false));
        }
    }
}
