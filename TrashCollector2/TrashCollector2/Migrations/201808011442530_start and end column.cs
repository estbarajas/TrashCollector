namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startandendcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerInfoes", "Start", c => c.String());
            AddColumn("dbo.CustomerInfoes", "End", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerInfoes", "End");
            DropColumn("dbo.CustomerInfoes", "Start");
        }
    }
}
