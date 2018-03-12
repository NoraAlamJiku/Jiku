namespace ProjectManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProjctId = c.Int(nullable: false),
                        AssignBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projcts", t => t.ProjctId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProjctId);
            
            CreateTable(
                "dbo.Projcts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CodeName = c.String(nullable: false, maxLength: 12),
                        Description = c.String(nullable: false, maxLength: 300),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        UploadFile = c.String(),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjctId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 300),
                        DueDate = c.DateTime(nullable: false),
                        PriorityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Priorities", t => t.PriorityId)
                .ForeignKey("dbo.Projcts", t => t.ProjctId)
                .Index(t => t.ProjctId)
                .Index(t => t.UserId)
                .Index(t => t.PriorityId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjctId = c.Int(nullable: false),
                        TasksId = c.Int(nullable: false),
                        Commentt = c.String(nullable: false, maxLength: 300),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.TasksId)
                .ForeignKey("dbo.Projcts", t => t.ProjctId)
                .Index(t => t.ProjctId)
                .Index(t => t.TasksId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 40),
                        DefaultPassword = c.String(),
                        Status = c.String(nullable: false, maxLength: 500),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.Email, unique: true, name: "Ix_Email")
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjctId", "dbo.Projcts");
            DropForeignKey("dbo.Tasks", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.AssignPersons", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "TasksId", "dbo.Tasks");
            DropForeignKey("dbo.AssignPersons", "ProjctId", "dbo.Projcts");
            DropIndex("dbo.Users", new[] { "DesignationId" });
            DropIndex("dbo.Users", "Ix_Email");
            DropIndex("dbo.Comments", new[] { "TasksId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Tasks", new[] { "PriorityId" });
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropIndex("dbo.Tasks", new[] { "ProjctId" });
            DropIndex("dbo.AssignPersons", new[] { "ProjctId" });
            DropIndex("dbo.AssignPersons", new[] { "UserId" });
            DropTable("dbo.Priorities");
            DropTable("dbo.Designations");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projcts");
            DropTable("dbo.AssignPersons");
        }
    }
}
