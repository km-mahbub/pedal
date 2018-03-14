namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLatLon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Addresses", "Lon", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "Lon");
            DropColumn("dbo.Addresses", "Lat");
        }
    }
}
