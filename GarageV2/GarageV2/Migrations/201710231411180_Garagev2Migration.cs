namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Garagev2Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        RegNo = c.String(),
                        Color = c.String(),
                        Brand = c.String(),
                        Modell = c.String(),
                        NumberOfWheels = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkedVehicles");
        }
    }
}
