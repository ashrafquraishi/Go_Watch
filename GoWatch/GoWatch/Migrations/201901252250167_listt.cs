namespace GoWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GuestLists", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GuestLists", "FullName");
        }
    }
}
