namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attendeelist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeEvents", "Going", c => c.Boolean(nullable: false));
            AddColumn("dbo.HomeEvents", "Arrived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomeEvents", "Arrived");
            DropColumn("dbo.HomeEvents", "Going");
        }
    }
}
