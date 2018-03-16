namespace Pedal.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFluent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "IsRented", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "IsRented", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "False", newValue: null)
                    },
                }));
        }
    }
}
