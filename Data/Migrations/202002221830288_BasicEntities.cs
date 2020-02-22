namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOrg = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        PublicDate = c.DateTime(nullable: false),
                        PlaceID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.PlaceID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coords = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feeds", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Feeds", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Feeds", new[] { "CategoryID" });
            DropIndex("dbo.Feeds", new[] { "PlaceID" });
            DropTable("dbo.Partners");
            DropTable("dbo.Places");
            DropTable("dbo.Feeds");
            DropTable("dbo.Categories");
            DropTable("dbo.Calendars");
        }
    }
}
