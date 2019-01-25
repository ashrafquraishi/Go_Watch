namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GuestLists", "BarEventID", "dbo.BarEvents");
            DropForeignKey("dbo.GuestLists", "FanID", "dbo.Fans");
            DropForeignKey("dbo.GuestLists", "EventID", "dbo.HomeEvents");
            DropIndex("dbo.GuestLists", new[] { "FanID" });
            DropIndex("dbo.GuestLists", new[] { "EventID" });
            DropIndex("dbo.GuestLists", new[] { "BarEventID" });
            DropColumn("dbo.GuestLists", "FanID");
            DropColumn("dbo.GuestLists", "EventID");
            DropColumn("dbo.GuestLists", "BarEventID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GuestLists", "BarEventID", c => c.Int(nullable: false));
            AddColumn("dbo.GuestLists", "EventID", c => c.Int(nullable: false));
            AddColumn("dbo.GuestLists", "FanID", c => c.Int(nullable: false));
            CreateIndex("dbo.GuestLists", "BarEventID");
            CreateIndex("dbo.GuestLists", "EventID");
            CreateIndex("dbo.GuestLists", "FanID");
            AddForeignKey("dbo.GuestLists", "EventID", "dbo.HomeEvents", "EventID", cascadeDelete: true);
            AddForeignKey("dbo.GuestLists", "FanID", "dbo.Fans", "FanID", cascadeDelete: true);
            AddForeignKey("dbo.GuestLists", "BarEventID", "dbo.BarEvents", "EventID", cascadeDelete: true);
        }
    }
}
