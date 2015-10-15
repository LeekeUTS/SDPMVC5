namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10151359 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminders", "passCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reminders", "passCode");
        }
    }
}
