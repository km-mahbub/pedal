namespace Pedal.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Lat = c.Double(nullable: false),
                        Lon = c.Double(nullable: false),
                        Area = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                        BookingStatus = c.Boolean(nullable: false),
                        BookingTrackId = c.String(nullable: false, maxLength: 255),
                        CycleId = c.Int(nullable: false),
                        IdentityId = c.String(),
                        RentId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                        BookingStatusTable_BookingStatusTableId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.BookingStatusTables", t => t.BookingStatusTable_BookingStatusTableId)
                .Index(t => t.BookingStatusTable_BookingStatusTableId);
            
            CreateTable(
                "dbo.BookingStatusTables",
                c => new
                    {
                        BookingStatusTableId = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        IsRented = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                    })
                .PrimaryKey(t => t.BookingStatusTableId);
            
            CreateTable(
                "dbo.CashMemoes",
                c => new
                    {
                        CashMemoId = c.Int(nullable: false, identity: true),
                        RentedHour = c.Int(nullable: false),
                        CashReceiveTime = c.DateTime(nullable: false),
                        ManagerId = c.String(),
                        CustomerId = c.String(),
                        RentId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                    })
                .PrimaryKey(t => t.CashMemoId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                    })
                .PrimaryKey(t => t.CompanyId);
            
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
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                        Booking_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.CycleId)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.StoreId)
                .Index(t => t.Booking_BookingId);
            
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
                        ManagerId = c.String(nullable: false),
                        CustomerId = c.String(),
                        TrackId = c.String(),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                        Booking_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId)
                .ForeignKey("dbo.Cycles", t => t.CycleId, cascadeDelete: true)
                .Index(t => t.CycleId)
                .Index(t => t.Booking_BookingId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        TotalCycle = c.Int(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        IdentityId = c.String(),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.ManagerLoginHistories",
                c => new
                    {
                        ManagerLoginHistoryId = c.Int(nullable: false, identity: true),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(nullable: false),
                        IdentityId = c.String(),
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                    })
                .PrimaryKey(t => t.ManagerLoginHistoryId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 64),
                        LastName = c.String(maxLength: 64),
                        DateOfBirth = c.DateTime(),
                        AddressId = c.Int(),
                        NationalId = c.String(),
                        PassportNumber = c.String(),
                        DrivingLicense = c.String(),
                        Gender = c.Int(),
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
                        IsDeleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Default",
                                    new AnnotationValues(oldValue: null, newValue: "False")
                                },
                            }),
                        StoreId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cycles", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Rents", "CycleId", "dbo.Cycles");
            DropForeignKey("dbo.Rents", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Cycles", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Cycles", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "BookingStatusTable_BookingStatusTableId", "dbo.BookingStatusTables");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Rents", new[] { "Booking_BookingId" });
            DropIndex("dbo.Rents", new[] { "CycleId" });
            DropIndex("dbo.Cycles", new[] { "Booking_BookingId" });
            DropIndex("dbo.Cycles", new[] { "StoreId" });
            DropIndex("dbo.Cycles", new[] { "CompanyId" });
            DropIndex("dbo.Bookings", new[] { "BookingStatusTable_BookingStatusTableId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
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
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ManagerLoginHistories",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                });
            DropTable("dbo.Stores",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                    {
                        "TotalCycle",
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
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                    {
                        "RentedHour",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
            DropTable("dbo.Cycles",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                    {
                        "RentedHour",
                        new Dictionary<string, object>
                        {
                            { "Default", "0" },
                        }
                    },
                });
            DropTable("dbo.Companies",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                });
            DropTable("dbo.CashMemoes",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                });
            DropTable("dbo.BookingStatusTables",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                });
            DropTable("dbo.Bookings",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                });
            DropTable("dbo.Addresses",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "IsDeleted",
                        new Dictionary<string, object>
                        {
                            { "Default", "False" },
                        }
                    },
                });
        }
    }
}
