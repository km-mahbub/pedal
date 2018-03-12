namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "Name");
        }
    }
}
