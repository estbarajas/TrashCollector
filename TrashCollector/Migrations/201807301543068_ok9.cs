namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok9 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AddColumn("dbo.Customers", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeId");
            CreateIndex("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Employees", "Id");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Address", c => c.String());
            AddColumn("dbo.Employees", "Password", c => c.String());
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "EmployeeId");
            DropColumn("dbo.Customers", "UserId");
            AddPrimaryKey("dbo.Employees", "Id");
        }
    }
}
