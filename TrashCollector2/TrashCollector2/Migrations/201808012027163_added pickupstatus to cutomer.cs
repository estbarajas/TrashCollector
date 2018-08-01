namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpickupstatustocutomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerInfoes", "PickupStatus", c => c.String());
            DropColumn("dbo.Schedules", "PickupStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "PickupStatus", c => c.String());
            DropColumn("dbo.CustomerInfoes", "PickupStatus");
        }
    }
}
