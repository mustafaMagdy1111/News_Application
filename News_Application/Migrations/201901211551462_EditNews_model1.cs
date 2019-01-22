namespace News_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNews_model1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "_News", c => c.String());
            DropColumn("dbo.News", "news");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "news", c => c.String());
            DropColumn("dbo.News", "_News");
        }
    }
}
