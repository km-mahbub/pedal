namespace Pedal.Data.Migrations
{
    using System;
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
                "dbo.UserAddresses",
                c => new
                    {
                        UserAddressId = c.Int(nullable: false, identity: true),
                        Area = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UserAddressId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                        BookingStatus = c.Boolean(nullable: false),
                        BookingTrackId = c.String(),
                        CycleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Cycles", t => t.CycleId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.CycleId);
            
            CreateTable(
                "dbo.Cycles",
                c => new
                    {
                        CycleId = c.Int(nullable: false, identity: true),
                        CycleStatusType = c.Int(nullable: false),
                        RentedHour = c.Int(nullable: false),
                        CycleType = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CycleId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        TotalCycle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        RentId = c.Int(nullable: false, identity: true),
                        CycleId = c.Int(nullable: false),
                        RentedHour = c.Int(nullable: false),
                        RentedTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(),
                        BookingId = c.Int(),
                        RentedFromStoreId = c.Int(nullable: false),
                        ToBeSubmittedStoreId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        RentedFromStore_StoreId = c.Int(),
                        ToBeSubmittedStore_StoreId = c.Int(),
                        Store_StoreId = c.Int(),
                        Store_StoreId1 = c.Int(),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .ForeignKey("dbo.Cycles", t => t.CycleId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.RentedFromStore_StoreId)
                .ForeignKey("dbo.Stores", t => t.ToBeSubmittedStore_StoreId)
                .ForeignKey("dbo.Stores", t => t.Store_StoreId)
                .ForeignKey("dbo.Stores", t => t.Store_StoreId1)
                .Index(t => t.CycleId)
                .Index(t => t.BookingId)
                .Index(t => t.RentedFromStore_StoreId)
                .Index(t => t.ToBeSubmittedStore_StoreId)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Store_StoreId1);
            
            CreateTable(
                "dbo.BookingStatusTables",
                c => new
                    {
                        BookingStatusTableId = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        IsRented = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookingStatusTableId)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.CashMemoes",
                c => new
                    {
                        CashMemoId = c.Int(nullable: false, identity: true),
                        RentId = c.Int(nullable: false),
                        RentedHour = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        CashReceiveTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CashMemoId)
                .ForeignKey("dbo.Rents", t => t.RentId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.RentId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        IdentityId = c.String(maxLength: 128),
                        TotalRentHour = c.Int(nullable: false),
                        TotalRentCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityId)
                .Index(t => t.IdentityId);
            
            CreateTable(
                "dbo.ManagerLoginHistories",
                c => new
                    {
                        ManagerLoginHistoryId = c.Int(nullable: false, identity: true),
                        LoginTime = c.DateTime(nullable: false),
                        LogoutTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerLoginHistoryId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        IdentityId = c.String(maxLength: 128),
                        StoreId = c.Int(nullable: false),
                        IsLoggedIn = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityId)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.IdentityId)
                .Index(t => t.StoreId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NationalId", c => c.String());
            AddColumn("dbo.AspNetUsers", "PassportNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserAddressId");
            AddForeignKey("dbo.AspNetUsers", "UserAddressId", "dbo.UserAddresses", "UserAddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Managers", "IdentityId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "IdentityId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CashMemoes", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.CashMemoes", "RentId", "dbo.Rents");
            DropForeignKey("dbo.BookingStatusTables", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "CycleId", "dbo.Cycles");
            DropForeignKey("dbo.Rents", "Store_StoreId1", "dbo.Stores");
            DropForeignKey("dbo.Rents", "Store_StoreId", "dbo.Stores");
            DropForeignKey("dbo.Rents", "ToBeSubmittedStore_StoreId", "dbo.Stores");
            DropForeignKey("dbo.Rents", "RentedFromStore_StoreId", "dbo.Stores");
            DropForeignKey("dbo.Rents", "CycleId", "dbo.Cycles");
            DropForeignKey("dbo.Rents", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Cycles", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Bookings", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Cycles", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Admins", "IdentityId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "UserAddressId", "dbo.UserAddresses");
            DropIndex("dbo.Managers", new[] { "StoreId" });
            DropIndex("dbo.Managers", new[] { "IdentityId" });
            DropIndex("dbo.Customers", new[] { "IdentityId" });
            DropIndex("dbo.CashMemoes", new[] { "StoreId" });
            DropIndex("dbo.CashMemoes", new[] { "RentId" });
            DropIndex("dbo.BookingStatusTables", new[] { "BookingId" });
            DropIndex("dbo.Rents", new[] { "Store_StoreId1" });
            DropIndex("dbo.Rents", new[] { "Store_StoreId" });
            DropIndex("dbo.Rents", new[] { "ToBeSubmittedStore_StoreId" });
            DropIndex("dbo.Rents", new[] { "RentedFromStore_StoreId" });
            DropIndex("dbo.Rents", new[] { "BookingId" });
            DropIndex("dbo.Rents", new[] { "CycleId" });
            DropIndex("dbo.Cycles", new[] { "StoreId" });
            DropIndex("dbo.Cycles", new[] { "CompanyId" });
            DropIndex("dbo.Bookings", new[] { "CycleId" });
            DropIndex("dbo.Bookings", new[] { "StoreId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserAddressId" });
            DropIndex("dbo.Admins", new[] { "IdentityId" });
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
            DropColumn("dbo.AspNetUsers", "PassportNumber");
            DropColumn("dbo.AspNetUsers", "NationalId");
            DropColumn("dbo.AspNetUsers", "UserAddressId");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Managers");
            DropTable("dbo.ManagerLoginHistories");
            DropTable("dbo.Customers");
            DropTable("dbo.CashMemoes");
            DropTable("dbo.BookingStatusTables");
            DropTable("dbo.Rents");
            DropTable("dbo.Stores");
            DropTable("dbo.Companies");
            DropTable("dbo.Cycles");
            DropTable("dbo.Bookings");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Admins");
        }
    }
}
