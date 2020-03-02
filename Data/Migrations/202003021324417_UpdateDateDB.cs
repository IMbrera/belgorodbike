namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calendars", "DateOrg", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calendars", "DateOrg", c => c.DateTime());
        }
    }
}
