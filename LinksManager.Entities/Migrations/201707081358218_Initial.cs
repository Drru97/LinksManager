namespace LinksManager.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Links", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Links", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Links", "Title", c => c.String());
            AlterColumn("dbo.Links", "Url", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
