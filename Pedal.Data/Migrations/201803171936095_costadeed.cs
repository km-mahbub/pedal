namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class costadeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashMemoes", "TotalCost", c => c.Int(nullable: false));
            AddColumn("dbo.Rents", "IsReceived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "IsReceived");
            DropColumn("dbo.CashMemoes", "TotalCost");
        }
    }
}
