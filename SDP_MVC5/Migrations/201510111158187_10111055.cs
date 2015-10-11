namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10111055 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Waitings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        workshopID = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Waitings");
        }
    }
}
