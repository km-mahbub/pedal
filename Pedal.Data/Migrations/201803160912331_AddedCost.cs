namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "BookingStatusTableId", "dbo.BookingStatusTables");
            DropIndex("dbo.Bookings", new[] { "BookingStatusTableId" });
            AddColumn("dbo.Bookings", "IsRented", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cycles", "CostPerHour", c => c.Double(nullable: false));
            DropColumn("dbo.Bookings", "BookingStatusTableId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "BookingStatusTableId", c => c.Int(nullable: false));
            DropColumn("dbo.Cycles", "CostPerHour");
            DropColumn("dbo.Bookings", "IsRented");
            CreateIndex("dbo.Bookings", "BookingStatusTableId");
            AddForeignKey("dbo.Bookings", "BookingStatusTableId", "dbo.BookingStatusTables", "BookingStatusTableId", cascadeDelete: true);
        }
    }
}
