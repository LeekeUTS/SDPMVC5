namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10151342 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "workshopName", c => c.String());
            AddColumn("dbo.Reminders", "workshopName", c => c.String());
            AddColumn("dbo.Waitings", "workshopName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Waitings", "workshopName");
            DropColumn("dbo.Reminders", "workshopName");
            DropColumn("dbo.Attendances", "workshopName");
        }
    }
}
