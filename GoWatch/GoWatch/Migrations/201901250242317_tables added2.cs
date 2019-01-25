namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesadded2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeEvents", "HomeEvent_EventID", c => c.Int());
            CreateIndex("dbo.HomeEvents", "HomeEvent_EventID");
            AddForeignKey("dbo.HomeEvents", "HomeEvent_EventID", "dbo.HomeEvents", "EventID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeEvents", "HomeEvent_EventID", "dbo.HomeEvents");
            DropIndex("dbo.HomeEvents", new[] { "HomeEvent_EventID" });
            DropColumn("dbo.HomeEvents", "HomeEvent_EventID");
        }
    }
}
