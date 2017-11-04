namespace GarageV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMember : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "MemberNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "MemberNo", c => c.Int(nullable: false));
        }
    }
}
