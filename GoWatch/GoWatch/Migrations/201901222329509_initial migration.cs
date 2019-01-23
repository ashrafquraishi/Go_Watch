namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BarEvents", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.HomeEvents", "FullName", c => c.String());
            AddColumn("dbo.HomeEvents", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.BarEvents", "ApplicationUserId");
            CreateIndex("dbo.HomeEvents", "ApplicationUserId");
            AddForeignKey("dbo.BarEvents", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.HomeEvents", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HomeEvents", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BarEvents", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.HomeEvents", new[] { "ApplicationUserId" });
            DropIndex("dbo.BarEvents", new[] { "ApplicationUserId" });
            DropColumn("dbo.HomeEvents", "ApplicationUserId");
            DropColumn("dbo.HomeEvents", "FullName");
            DropColumn("dbo.BarEvents", "ApplicationUserId");
        }
    }
}
