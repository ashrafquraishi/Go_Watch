namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bcas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fans", "Planning", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fans", "Planning");
        }
    }
}
