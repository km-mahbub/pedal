namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingDatanase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "CustomerId", c => c.String());
            AddColumn("dbo.Stores", "ManagerId", c => c.String());
            AddColumn("dbo.ManagerLoginHistories", "ManagerId", c => c.String());
            DropColumn("dbo.Bookings", "IdentityId");
            DropColumn("dbo.Stores", "IdentityId");
            DropColumn("dbo.ManagerLoginHistories", "IdentityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ManagerLoginHistories", "IdentityId", c => c.String());
            AddColumn("dbo.Stores", "IdentityId", c => c.String());
            AddColumn("dbo.Bookings", "IdentityId", c => c.String());
            DropColumn("dbo.ManagerLoginHistories", "ManagerId");
            DropColumn("dbo.Stores", "ManagerId");
            DropColumn("dbo.Bookings", "CustomerId");
        }
    }
}
