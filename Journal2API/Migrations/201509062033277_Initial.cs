namespace Journal2API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                        Author = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Workflow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workflows", t => t.Workflow_Id)
                .Index(t => t.Workflow_Id);
            
            CreateTable(
                "dbo.Workflows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Parent_Id = c.Int(),
                        Workflow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TodoItems", t => t.Parent_Id)
                .ForeignKey("dbo.Workflows", t => t.Workflow_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.Workflow_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoItems", "Workflow_Id", "dbo.Workflows");
            DropForeignKey("dbo.TodoItems", "Parent_Id", "dbo.TodoItems");
            DropForeignKey("dbo.Quests", "Workflow_Id", "dbo.Workflows");
            DropIndex("dbo.TodoItems", new[] { "Workflow_Id" });
            DropIndex("dbo.TodoItems", new[] { "Parent_Id" });
            DropIndex("dbo.Quests", new[] { "Workflow_Id" });
            DropTable("dbo.TodoItems");
            DropTable("dbo.Workflows");
            DropTable("dbo.Quests");
            DropTable("dbo.LogItems");
            DropTable("dbo.Comments");
        }
    }
}
