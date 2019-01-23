namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jjj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BarEvents", "EventTime", c => c.DateTime());
            AddColumn("dbo.HomeEvents", "EventTime", c => c.DateTime());
            DropColumn("dbo.HomeEvents", "RateEvent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomeEvents", "RateEvent", c => c.Int(nullable: false));
            DropColumn("dbo.HomeEvents", "EventTime");
            DropColumn("dbo.BarEvents", "EventTime");
        }
    }
}
