namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingscheduleandinvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Address", c => c.String());
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ZipCode");
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Customers", "ZipCode");
            DropColumn("dbo.Customers", "Address");
        }
    }
}
