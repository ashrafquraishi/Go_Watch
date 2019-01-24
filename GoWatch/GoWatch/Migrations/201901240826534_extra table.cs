namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extratable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestLists",
                c => new
                    {
                        GuestListID = c.Int(nullable: false, identity: true),
                        Going = c.Boolean(nullable: false),
                        Arrived = c.Boolean(nullable: false),
                        FanID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        BarEventID = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GuestListID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.BarEvents", t => t.BarEventID, cascadeDelete: true)
                .ForeignKey("dbo.Fans", t => t.FanID, cascadeDelete: true)
                .ForeignKey("dbo.HomeEvents", t => t.EventID, cascadeDelete: true)
                .Index(t => t.FanID)
                .Index(t => t.EventID)
                .Index(t => t.BarEventID)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestLists", "EventID", "dbo.HomeEvents");
            DropForeignKey("dbo.GuestLists", "FanID", "dbo.Fans");
            DropForeignKey("dbo.GuestLists", "BarEventID", "dbo.BarEvents");
            DropForeignKey("dbo.GuestLists", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.GuestLists", new[] { "ApplicationUserId" });
            DropIndex("dbo.GuestLists", new[] { "BarEventID" });
            DropIndex("dbo.GuestLists", new[] { "EventID" });
            DropIndex("dbo.GuestLists", new[] { "FanID" });
            DropTable("dbo.GuestLists");
        }
    }
}
