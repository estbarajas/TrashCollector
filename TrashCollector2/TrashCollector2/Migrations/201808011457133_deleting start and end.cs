namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingstartandend : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerInfoes", "Start");
            DropColumn("dbo.CustomerInfoes", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerInfoes", "End", c => c.String());
            AddColumn("dbo.CustomerInfoes", "Start", c => c.String());
        }
    }
}
