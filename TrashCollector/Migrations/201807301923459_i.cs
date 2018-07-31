namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "UserId");
            CreateIndex("dbo.Customers", "UserId");
            DropColumn("dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Customers", "Id");
            CreateIndex("dbo.Customers", "UserId");
        }
    }
}
