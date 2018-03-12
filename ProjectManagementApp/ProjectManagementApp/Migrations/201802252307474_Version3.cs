namespace ProjectManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentBy");
        }
    }
}
