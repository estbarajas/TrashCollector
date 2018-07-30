namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Customers", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationUser_Id");
            AddForeignKey("dbo.Customers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
