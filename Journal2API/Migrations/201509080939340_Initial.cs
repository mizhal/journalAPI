namespace Journal2API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                        Author = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "LogItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(unicode: false),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Quests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "TodoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("TodoItems", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "WorkflowDefinitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(maxLength: 128, storeType: "nvarchar"),
                        Workflow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Workflows", t => t.Workflow_Id)
                .Index(t => t.ClassName, unique: true, name: Definition)
                .Index(t => t.Workflow_Id);
            
            CreateTable(
                "Workflows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 64, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)                
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "WorkflowStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128, storeType: "nvarchar"),
                        Workflow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Workflows", t => t.Workflow_Id)
                .Index(t => t.Name, unique: true, name: StateName)
                .Index(t => t.Workflow_Id);
            
            CreateTable(
                "WorkflowTransitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Destination_Id = c.Int(),
                        Origin_Id = c.Int(),
                        Workflow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("WorkflowStates", t => t.Destination_Id)
                .ForeignKey("WorkflowStates", t => t.Origin_Id)
                .ForeignKey("Workflows", t => t.Workflow_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Origin_Id)
                .Index(t => t.Workflow_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("WorkflowDefinitions", "Workflow_Id", "Workflows");
            DropForeignKey("WorkflowTransitions", "Workflow_Id", "Workflows");
            DropForeignKey("WorkflowTransitions", "Origin_Id", "WorkflowStates");
            DropForeignKey("WorkflowTransitions", "Destination_Id", "WorkflowStates");
            DropForeignKey("WorkflowStates", "Workflow_Id", "Workflows");
            DropForeignKey("TodoItems", "Parent_Id", "TodoItems");
            DropIndex("WorkflowTransitions", new[] { "Workflow_Id" });
            DropIndex("WorkflowTransitions", new[] { "Origin_Id" });
            DropIndex("WorkflowTransitions", new[] { "Destination_Id" });
            DropIndex("WorkflowStates", new[] { "Workflow_Id" });
            DropIndex("WorkflowStates", "StateName");
            DropIndex("Workflows", new[] { "Name" });
            DropIndex("WorkflowDefinitions", new[] { "Workflow_Id" });
            DropIndex("WorkflowDefinitions", "Definition");
            DropIndex("TodoItems", new[] { "Parent_Id" });
            DropTable("WorkflowTransitions");
            DropTable("WorkflowStates");
            DropTable("Workflows");
            DropTable("WorkflowDefinitions");
            DropTable("TodoItems");
            DropTable("Quests");
            DropTable("LogItems");
            DropTable("Comments");
        }
    }
}
