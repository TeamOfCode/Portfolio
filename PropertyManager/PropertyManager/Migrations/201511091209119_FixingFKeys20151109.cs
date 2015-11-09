namespace PropertyManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingFKeys20151109 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Property_PropertyId", "dbo.Properties");
            DropIndex("dbo.AspNetUsers", new[] { "Property_PropertyId" });
            AlterColumn("dbo.Properties", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Properties", "UserId");
            AddForeignKey("dbo.Properties", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Property_PropertyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Property_PropertyId", c => c.Int());
            DropForeignKey("dbo.Properties", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Properties", new[] { "UserId" });
            AlterColumn("dbo.Properties", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Property_PropertyId");
            AddForeignKey("dbo.AspNetUsers", "Property_PropertyId", "dbo.Properties", "PropertyId");
        }
    }
}
