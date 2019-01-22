namespace News_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAuthor_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Name");
        }
    }
}
