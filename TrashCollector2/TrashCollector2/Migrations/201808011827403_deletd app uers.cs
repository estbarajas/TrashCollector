namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletdappuers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeInfoes", new[] { "UserId" });
            DropTable("dbo.EmployeeInfoes");
        }
    }
}
