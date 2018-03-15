namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "BookingStatusTable_BookingStatusTableId", "dbo.BookingStatusTables");
            DropIndex("dbo.Bookings", new[] { "BookingStatusTable_BookingStatusTableId" });
            RenameColumn(table: "dbo.Bookings", name: "BookingStatusTable_BookingStatusTableId", newName: "BookingStatusTableId");
            
            DropColumn("dbo.Bookings", "RentId");
            DropColumn("dbo.BookingStatusTables", "BookingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingStatusTables", "BookingId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "RentId", c => c.Int());
            
            RenameColumn(table: "dbo.Bookings", name: "BookingStatusTableId", newName: "BookingStatusTable_BookingStatusTableId");
            CreateIndex("dbo.Bookings", "BookingStatusTable_BookingStatusTableId");
            AddForeignKey("dbo.Bookings", "BookingStatusTable_BookingStatusTableId", "dbo.BookingStatusTables", "BookingStatusTableId");
        }
    }
}
