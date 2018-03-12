namespace ProjectManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Projct_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Projct_Id");
            AddForeignKey("dbo.Comments", "Projct_Id", "dbo.Projcts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Projct_Id", "dbo.Projcts");
            DropIndex("dbo.Comments", new[] { "Projct_Id" });
            DropColumn("dbo.Comments", "Projct_Id");
        }
    }
}
