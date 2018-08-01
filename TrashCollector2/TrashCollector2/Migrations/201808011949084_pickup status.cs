namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "PickupStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "PickupStatus");
        }
    }
}
