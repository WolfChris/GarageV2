namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleTypeEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "Model", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.ParkedVehicles", "Modell");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "Modell", c => c.String());
            AlterColumn("dbo.ParkedVehicles", "Type", c => c.String());
            DropColumn("dbo.ParkedVehicles", "Model");
        }
    }
}
