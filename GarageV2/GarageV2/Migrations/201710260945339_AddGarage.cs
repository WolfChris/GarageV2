namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGarage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                   "dbo.Garage",
                   c => new
                   {
                       Id = c.Int(nullable: false, identity: true),
                       Capacity = c.Int(nullable: true),
                       PricePerHour = c.Double(nullable: true),
                   })
                   .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Garage");
        }
    }
}
