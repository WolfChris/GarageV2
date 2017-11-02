namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckInViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "Discriminator");
        }
    }
}
