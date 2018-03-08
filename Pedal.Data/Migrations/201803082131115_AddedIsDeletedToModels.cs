namespace Pedal.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeletedToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Addresses", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Stores", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Bookings", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.BookingStatusTables", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Customers", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.CashMemoes", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Managers", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.ManagerLoginHistories", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Rents", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Cycles", "IsDeleted", c => c.Boolean(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AddColumn("dbo.Companies", "IsDeleted", c => c.Boolean(nullable: false,
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
            DropColumn("dbo.Companies", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Cycles", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Rents", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.ManagerLoginHistories", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Managers", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.CashMemoes", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Customers", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.BookingStatusTables", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Bookings", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Stores", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Addresses", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.AspNetUsers", "IsDeleted",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "False" },
                });
            DropColumn("dbo.Admins", "IsDeleted");
        }
    }
}
