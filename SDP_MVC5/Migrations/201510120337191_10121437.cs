namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10121437 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Waitings", "bookingID", c => c.Int(nullable: false));
            AddColumn("dbo.Waitings", "createdtime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Attendances", "attendancetime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Attendances", "status");
            DropColumn("dbo.Reminders", "status");
            DropColumn("dbo.Waitings", "created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Waitings", "created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reminders", "status", c => c.String());
            AddColumn("dbo.Attendances", "status", c => c.String());
            AlterColumn("dbo.Attendances", "attendancetime", c => c.DateTime());
            DropColumn("dbo.Waitings", "createdtime");
            DropColumn("dbo.Waitings", "bookingID");
        }
    }
}
