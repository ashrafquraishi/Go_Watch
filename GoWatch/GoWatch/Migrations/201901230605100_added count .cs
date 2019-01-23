namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcount : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Counts");
        }
    }
}
