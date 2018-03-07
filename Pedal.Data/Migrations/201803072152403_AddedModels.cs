namespace Pedal.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        IdentityId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AdminId)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityId)
                .Index(t => t.IdentityId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Area = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        TotalCycle = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                        BookingStatus = c.Boolean(nullable: false),
                        BookingTrackId = c.String(nullable: false, maxLength: 255),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Cycles", t => t.BookingId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.BookingId)
                .Index(t => t.StoreId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.BookingStatusTables",
                c => new
                    {
                        BookingStatusTableId = c.Int(nullable: false),
                        IsRented = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookingStatusTableId)
                .ForeignKey("dbo.Bookings", t => t.BookingStatusTableId)
                .Index(t => t.BookingStatusTableId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        IdentityId = c.String(maxLength: 128),
                        TotalRentHour = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        TotalRentCount = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityId)
                .Index(t => t.IdentityId);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        RentId = c.Int(nullable: false, identity: true),
                        CycleId = c.Int(nullable: false),
                        RentedHour = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        RentedTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(),
                        RentedFromStoreId = c.Int(nullable: false),
                        ToBeSubmittedStoreId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Booking_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Cycles", t => t.CycleId)
                .ForeignKey("dbo.Managers", t => t.ManagerId)
                .ForeignKey("dbo.Stores", t => t.RentedFromStoreId)
                .ForeignKey("dbo.Stores", t => t.ToBeSubmittedStoreId)
                .Index(t => t.CycleId)
                .Index(t => t.RentedFromStoreId)
                .Index(t => t.ToBeSubmittedStoreId)
                .Index(t => t.ManagerId)
                .Index(t => t.CustomerId)
                .Index(t => t.Booking_BookingId);
            
            CreateTable(
                "dbo.Cycles",
                c => new
                    {
                        CycleId = c.Int(nullable: false, identity: true),
                        CycleStatusType = c.Int(nullable: false),
                        RentedHour = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        CycleType = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CycleId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Stores", t => t.StoreId)
                .Index(t => t.CompanyId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false),
                        IdentityId = c.String(maxLength: 128),
                        IsLoggedIn = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                    })
                .PrimaryKey(t => t.ManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityId)
                .ForeignKey("dbo.Stores", t => t.ManagerId)
                .Index(t => t.ManagerId)
                .Index(t => t.IdentityId);
            
            CreateTable(
                "dbo.CashMemoes",
                c => new
                    {
                        CashMemoId = c.Int(nullable: false, identity: true),
                        RentedHour = c.Int(nullable: false),
                        CashReceiveTime = c.DateTime(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        RentId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CashMemoId)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .ForeignKey("dbo.Rents", t => t.RentId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ManagerId)
                .Index(t => t.RentId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.ManagerLoginHistories",
                c => new
                    {
                        ManagerLoginHistoryId = c.Int(nullable: false, identity: true),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerLoginHistoryId)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 64));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 64));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "4-4-1900")
                    },
                }));
            AddColumn("dbo.AspNetUsers", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NationalId", c => c.String());
            AddColumn("dbo.AspNetUsers", "PassportNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "AddressId");
            AddForeignKey("dbo.AspNetUsers", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "IdentityId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Bookings", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Bookings", "BookingId", "dbo.Cycles");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rents", "ToBeSubmittedStoreId", "dbo.Stores");
            DropForeignKey("dbo.Rents", "RentedFromStoreId", "dbo.Stores");
            DropForeignKey("dbo.Rents", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Managers", "ManagerId", "dbo.Stores");
            DropForeignKey("dbo.ManagerLoginHistories", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Managers", "IdentityId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CashMemoes", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.CashMemoes", "RentId", "dbo.Rents");
            DropForeignKey("dbo.CashMemoes", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Rents", "CycleId", "dbo.Cycles");
            DropForeignKey("dbo.Cycles", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Cycles", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rents", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Customers", "IdentityId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookingStatusTables", "BookingStatusTableId", "dbo.Bookings");
            DropForeignKey("dbo.Stores", "AddressId", "dbo.Addresses");
            DropIndex("dbo.ManagerLoginHistories", new[] { "ManagerId" });
            DropIndex("dbo.CashMemoes", new[] { "StoreId" });
            DropIndex("dbo.CashMemoes", new[] { "RentId" });
            DropIndex("dbo.CashMemoes", new[] { "ManagerId" });
            DropIndex("dbo.Managers", new[] { "IdentityId" });
            DropIndex("dbo.Managers", new[] { "ManagerId" });
            DropIndex("dbo.Cycles", new[] { "StoreId" });
            DropIndex("dbo.Cycles", new[] { "CompanyId" });
            DropIndex("dbo.Rents", new[] { "Booking_BookingId" });
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            DropIndex("dbo.Rents", new[] { "ManagerId" });
            DropIndex("dbo.Rents", new[] { "ToBeSubmittedStoreId" });
            DropIndex("dbo.Rents", new[] { "RentedFromStoreId" });
            DropIndex("dbo.Rents", new[] { "CycleId" });
            DropIndex("dbo.Customers", new[] { "IdentityId" });
            DropIndex("dbo.BookingStatusTables", new[] { "BookingStatusTableId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.Bookings", new[] { "StoreId" });
            DropIndex("dbo.Bookings", new[] { "BookingId" });
            DropIndex("dbo.Stores", new[] { "AddressId" });
            DropIndex("dbo.AspNetUsers", new[] { "AddressId" });
            DropIndex("dbo.Admins", new[] { "IdentityId" });
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
            DropColumn("dbo.AspNetUsers", "PassportNumber");
            DropColumn("dbo.AspNetUsers", "NationalId");
            DropColumn("dbo.AspNetUsers", "AddressId");
            DropColumn("dbo.AspNetUsers", "DateOfBirth",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Default", "4-4-1900" },
                });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.ManagerLoginHistories");
            DropTable("dbo.CashMemoes");
            DropTable("dbo.Managers",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsLoggedIn",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
            DropTable("dbo.Companies");
            DropTable("dbo.Cycles",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "RentedHour",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
            DropTable("dbo.Rents",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "RentedHour",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
            DropTable("dbo.Customers",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "TotalRentCount",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                    {
                        "TotalRentHour",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
            DropTable("dbo.BookingStatusTables");
            DropTable("dbo.Bookings");
            DropTable("dbo.Stores",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "TotalCycle",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
            DropTable("dbo.Addresses");
            DropTable("dbo.Admins");
        }
    }
}
