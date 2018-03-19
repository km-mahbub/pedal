namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookingsupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "CycleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "CycleName");
        }
    }
}
