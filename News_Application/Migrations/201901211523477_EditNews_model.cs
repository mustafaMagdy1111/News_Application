namespace News_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNews_model : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
