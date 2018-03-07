namespace Pedal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreDbRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashMemoes", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CashMemoes", "CustomerId");
            AddForeignKey("dbo.CashMemoes", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashMemoes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CashMemoes", new[] { "CustomerId" });
            DropColumn("dbo.CashMemoes", "CustomerId");
        }
    }
}
