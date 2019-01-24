namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lkjh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Fans", "Planning");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fans", "Planning", c => c.Boolean());
        }
    }
}
