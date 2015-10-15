namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10151914 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Waitings", "workshopName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waitings", "workshopName", c => c.String());
        }
    }
}
