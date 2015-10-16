namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10161721 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Waitings", "bookingID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Waitings", "bookingID", c => c.Int(nullable: false));
        }
    }
}
