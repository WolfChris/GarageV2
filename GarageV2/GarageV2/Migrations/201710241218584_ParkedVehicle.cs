namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "RegNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "RegNo", c => c.String());
        }
    }
}
