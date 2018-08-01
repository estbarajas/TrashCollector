namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstartandendtoschedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "Start", c => c.String());
            AddColumn("dbo.Schedules", "End", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "End");
            DropColumn("dbo.Schedules", "Start");
        }
    }
}
