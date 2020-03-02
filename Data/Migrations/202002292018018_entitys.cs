namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entitys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "PlaceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Calendars", "PlaceID");
            AddForeignKey("dbo.Calendars", "PlaceID", "dbo.Places", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calendars", "PlaceID", "dbo.Places");
            DropIndex("dbo.Calendars", new[] { "PlaceID" });
            DropColumn("dbo.Calendars", "PlaceID");
        }
    }
}
