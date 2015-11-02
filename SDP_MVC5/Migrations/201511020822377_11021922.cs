namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11021922 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        workshopID = c.Int(nullable: false),
                        bookingID = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                        createdtime = c.DateTime(nullable: false),
                        attendancetime = c.DateTime(nullable: false),
                        workshopName = c.String(nullable: false),
                        passCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        workshopID = c.Int(nullable: false),
                        bookingID = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                        createdtime = c.DateTime(nullable: false),
                        remindertime = c.DateTime(nullable: false),
                        workshopName = c.String(nullable: false),
                        starting = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Waitings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        workshopID = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                        createdtime = c.DateTime(nullable: false),
                        workshopName = c.String(nullable: false),
                        workshopSetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Waitings");
            DropTable("dbo.Reminders");
            DropTable("dbo.Attendances");
        }
    }
}
