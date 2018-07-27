namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingscheduleandinvoiceidtocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ScheduleId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "ScheduleId");
            CreateIndex("dbo.Customers", "InvoiceId");
            AddForeignKey("dbo.Customers", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "ScheduleId", "dbo.Schedules", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Customers", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Customers", new[] { "InvoiceId" });
            DropIndex("dbo.Customers", new[] { "ScheduleId" });
            DropColumn("dbo.Customers", "InvoiceId");
            DropColumn("dbo.Customers", "ScheduleId");
        }
    }
}
