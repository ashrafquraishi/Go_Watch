namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        AutoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AutoId);
            
            CreateTable(
                "dbo.ArticlesComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        ThisDateTime = c.DateTime(),
                        ArticleId = c.Int(nullable: false),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.BarEvents",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        BarName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        TeamName = c.String(),
                        EventTime = c.DateTime(),
                        Time = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Counts",
                c => new
                    {
                        CountId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Countdate = c.DateTime(nullable: false),
                        Countlike = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountId);
            
            CreateTable(
                "dbo.Fans",
                c => new
                    {
                        FanID = c.Int(nullable: false, identity: true),
                        FavoriteTeam = c.String(),
                        FullName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FanID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
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
            
            CreateTable(
                "dbo.HomeEvents",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        TeamName = c.String(),
                        Rules = c.String(),
                        EventTime = c.DateTime(),
                        Time = c.String(),
                        Price = c.Double(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GuestLists", "EventID", "dbo.HomeEvents");
            DropForeignKey("dbo.HomeEvents", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GuestLists", "FanID", "dbo.Fans");
            DropForeignKey("dbo.GuestLists", "BarEventID", "dbo.BarEvents");
            DropForeignKey("dbo.GuestLists", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fans", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BarEvents", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.HomeEvents", new[] { "ApplicationUserId" });
            DropIndex("dbo.GuestLists", new[] { "ApplicationUserId" });
            DropIndex("dbo.GuestLists", new[] { "BarEventID" });
            DropIndex("dbo.GuestLists", new[] { "EventID" });
            DropIndex("dbo.GuestLists", new[] { "FanID" });
            DropIndex("dbo.Fans", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BarEvents", new[] { "ApplicationUserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.HomeEvents");
            DropTable("dbo.GuestLists");
            DropTable("dbo.Fans");
            DropTable("dbo.Counts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BarEvents");
            DropTable("dbo.ArticlesComments");
            DropTable("dbo.Articles");
        }
    }
}
