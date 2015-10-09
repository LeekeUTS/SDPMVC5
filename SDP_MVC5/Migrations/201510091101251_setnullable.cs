namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attendances", "attendancetime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attendances", "attendancetime", c => c.DateTime(nullable: false));
        }
    }
}
