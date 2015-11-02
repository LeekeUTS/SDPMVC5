namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11021332 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminders", "starting", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reminders", "starting");
        }
    }
}
