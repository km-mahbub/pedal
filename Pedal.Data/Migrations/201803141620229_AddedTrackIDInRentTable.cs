namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrackIDInRentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "TrackId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "TrackId");
        }
    }
}
