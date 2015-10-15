namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10151407 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "passCode", c => c.String());
            DropColumn("dbo.Reminders", "passCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reminders", "passCode", c => c.String());
            DropColumn("dbo.Attendances", "passCode");
        }
    }
}
