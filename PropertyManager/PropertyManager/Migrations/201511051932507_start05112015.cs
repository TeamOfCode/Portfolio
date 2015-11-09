namespace PropertyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start05112015 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Property_PropertyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_PropertyId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Property_PropertyId);
            
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        TransactionTypeId = c.Int(nullable: false),
                        PropertyTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PropertyCategory = c.String(maxLength: 50),
                        BuildingType = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LotArea = c.Decimal(precision: 18, scale: 2),
                        Floor = c.Int(),
                        Standard = c.String(),
                        RoomsAmount = c.Int(),
                        BuildYear = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImprovedLand = c.String(maxLength: 50),
                        Description = c.String(nullable: false),
                        Advertiser = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 9),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeId)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeId)
                .Index(t => t.TransactionTypeId)
                .Index(t => t.PropertyTypeId);
            
            CreateTable(
                "dbo.PropertyPhotoes",
                c => new
                    {
                        FotoId = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        FotoSize = c.Int(nullable: false),
                        FileName = c.String(),
                        Description = c.String(),
                        FotoData = c.Binary(),
                        FotoMiniatureData = c.Binary(),
                    })
                .PrimaryKey(t => t.FotoId)
                .ForeignKey("dbo.Properties", t => t.PropertyId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        PropertyTypeId = c.Int(nullable: false, identity: true),
                        TypePropertyType = c.String(),
                    })
                .PrimaryKey(t => t.PropertyTypeId);
            
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
                "dbo.TransactionTypes",
                c => new
                    {
                        TransactionTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TransactionTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Properties", "TransactionTypeId", "dbo.TransactionTypes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Properties", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.AspNetUsers", "Property_PropertyId", "dbo.Properties");
            DropForeignKey("dbo.PropertyPhotoes", "PropertyId", "dbo.Properties");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PropertyPhotoes", new[] { "PropertyId" });
            DropIndex("dbo.Properties", new[] { "PropertyTypeId" });
            DropIndex("dbo.Properties", new[] { "TransactionTypeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Property_PropertyId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.PropertyPhotoes");
            DropTable("dbo.Properties");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
        }
    }
}
