namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10161642 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Waitings", "WorkShopSetID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Waitings", "WorkShopSetID");
        }
    }
}
