namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BarEvents", "Time", c => c.String());
            AddColumn("dbo.HomeEvents", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomeEvents", "Time");
            DropColumn("dbo.BarEvents", "Time");
        }
    }
}
