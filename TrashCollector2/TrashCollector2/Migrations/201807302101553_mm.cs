namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        ZipCode = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ScheduleId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountDue = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NormalDayPickUp = c.String(),
                        ExtraDatePickUp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerInfoes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerInfoes", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.CustomerInfoes", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.CustomerInfoes", new[] { "InvoiceId" });
            DropIndex("dbo.CustomerInfoes", new[] { "ScheduleId" });
            DropIndex("dbo.CustomerInfoes", new[] { "UserId" });
            DropTable("dbo.Schedules");
            DropTable("dbo.Invoices");
            DropTable("dbo.CustomerInfoes");
        }
    }
}
