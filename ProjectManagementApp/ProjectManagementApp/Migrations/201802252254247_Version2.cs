namespace ProjectManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "Projct_Id" });
            RenameColumn(table: "dbo.Comments", name: "Projct_Id", newName: "ProjctId");
            AlterColumn("dbo.Comments", "ProjctId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ProjctId");
            DropColumn("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            DropIndex("dbo.Comments", new[] { "ProjctId" });
            AlterColumn("dbo.Comments", "ProjctId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "ProjctId", newName: "Projct_Id");
            CreateIndex("dbo.Comments", "Projct_Id");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id");
        }
    }
}
