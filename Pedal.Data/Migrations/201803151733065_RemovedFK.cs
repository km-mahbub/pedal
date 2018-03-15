namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cycles", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Cycles", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Rents", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Cycles", "StoreId", "dbo.Stores");
            DropIndex("dbo.Cycles", new[] { "CompanyId" });
            DropIndex("dbo.Cycles", new[] { "StoreId" });
            DropIndex("dbo.Cycles", new[] { "Booking_BookingId" });
            DropIndex("dbo.Rents", new[] { "Booking_BookingId" });
            AddColumn("dbo.Rents", "BookingId", c => c.Int());
            DropColumn("dbo.Cycles", "Booking_BookingId");
            DropColumn("dbo.Rents", "Booking_BookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "Booking_BookingId", c => c.Int());
            AddColumn("dbo.Cycles", "Booking_BookingId", c => c.Int());
            DropColumn("dbo.Rents", "BookingId");
            CreateIndex("dbo.Rents", "Booking_BookingId");
            CreateIndex("dbo.Cycles", "Booking_BookingId");
            CreateIndex("dbo.Cycles", "StoreId");
            CreateIndex("dbo.Cycles", "CompanyId");
            AddForeignKey("dbo.Cycles", "StoreId", "dbo.Stores", "StoreId", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "Booking_BookingId", "dbo.Bookings", "BookingId");
            AddForeignKey("dbo.Cycles", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
            AddForeignKey("dbo.Cycles", "Booking_BookingId", "dbo.Bookings", "BookingId");
        }
    }
}
