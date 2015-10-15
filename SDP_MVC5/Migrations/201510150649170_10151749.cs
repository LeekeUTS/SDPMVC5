namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10151749 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "workshopName", c => c.String(nullable: false));
            AlterColumn("dbo.Attendances", "passCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "passCode", c => c.String());
            AlterColumn("dbo.Attendances", "workshopName", c => c.String());
        }
    }
}
