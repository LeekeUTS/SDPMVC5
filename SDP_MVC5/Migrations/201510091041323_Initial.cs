namespace SDP_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        bookingID = c.Int(nullable: false),
                        workshopID = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                        createdtime = c.DateTime(nullable: false),
                        attendancetime = c.DateTime(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        workshopID = c.Int(nullable: false),
                        studentID = c.Int(nullable: false),
                        createdtime = c.DateTime(nullable: false),
                        remindertime = c.DateTime(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reminders");
            DropTable("dbo.Movies");
            DropTable("dbo.Attendances");
        }
    }
}
