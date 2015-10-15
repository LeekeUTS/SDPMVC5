namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1015141 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reminders", "workshopName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reminders", "workshopName", c => c.String());
        }
    }
}
