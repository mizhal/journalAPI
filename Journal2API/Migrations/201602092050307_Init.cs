namespace Journal2API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Comments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                        Author = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        ClassName = c.String(unicode: false),
                        ObjectId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "LogItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(unicode: false),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Quests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(maxLength: 4098, storeType: "nvarchar"),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Position = c.Long(nullable: false),
                        DeletedAt = c.DateTime(precision: 0),
                        State_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("WorkflowStates", t => t.State_Id, cascadeDelete: true)
                .Index(t => t.State_Id);
            
            CreateTable(
                "WorkflowStates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeletedAt = c.DateTime(precision: 0),
                        Name = c.String(maxLength: 128, storeType: "nvarchar"),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Workflow_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Workflows", t => t.Workflow_Id)
                .Index(t => t.Name, unique: true, name: "StateName")
                .Index(t => t.Workflow_Id);
            
            CreateTable(
                "Workflows",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeletedAt = c.DateTime(precision: 0),
                        Name = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)                
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "WorkflowTransitions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeletedAt = c.DateTime(precision: 0),
                        Destination_Id = c.Long(),
                        Origin_Id = c.Long(),
                        Workflow_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("WorkflowStates", t => t.Destination_Id)
                .ForeignKey("WorkflowStates", t => t.Origin_Id)
                .ForeignKey("Workflows", t => t.Workflow_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Origin_Id)
                .Index(t => t.Workflow_Id);
            
            CreateTable(
                "TodoItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Position = c.Long(nullable: false),
                        DeletedAt = c.DateTime(precision: 0),
                        Parent_Id = c.Long(),
                        State_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("TodoItems", t => t.Parent_Id)
                .ForeignKey("WorkflowStates", t => t.State_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "WorkflowDefinitions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeletedAt = c.DateTime(precision: 0),
                        ClassName = c.String(maxLength: 128, storeType: "nvarchar"),
                        Workflow_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Workflows", t => t.Workflow_Id)
                .Index(t => t.ClassName, unique: true, name: "Definition")
                .Index(t => t.Workflow_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("WorkflowDefinitions", "Workflow_Id", "Workflows");
            DropForeignKey("TodoItems", "State_Id", "WorkflowStates");
            DropForeignKey("TodoItems", "Parent_Id", "TodoItems");
            DropForeignKey("Quests", "State_Id", "WorkflowStates");
            DropForeignKey("WorkflowTransitions", "Workflow_Id", "Workflows");
            DropForeignKey("WorkflowTransitions", "Origin_Id", "WorkflowStates");
            DropForeignKey("WorkflowTransitions", "Destination_Id", "WorkflowStates");
            DropForeignKey("WorkflowStates", "Workflow_Id", "Workflows");
            DropIndex("WorkflowDefinitions", new[] { "Workflow_Id" });
            DropIndex("WorkflowDefinitions", "Definition");
            DropIndex("TodoItems", new[] { "State_Id" });
            DropIndex("TodoItems", new[] { "Parent_Id" });
            DropIndex("WorkflowTransitions", new[] { "Workflow_Id" });
            DropIndex("WorkflowTransitions", new[] { "Origin_Id" });
            DropIndex("WorkflowTransitions", new[] { "Destination_Id" });
            DropIndex("Workflows", new[] { "Name" });
            DropIndex("WorkflowStates", new[] { "Workflow_Id" });
            DropIndex("WorkflowStates", "StateName");
            DropIndex("Quests", new[] { "State_Id" });
            DropTable("WorkflowDefinitions");
            DropTable("TodoItems");
            DropTable("WorkflowTransitions");
            DropTable("Workflows");
            DropTable("WorkflowStates");
            DropTable("Quests");
            DropTable("LogItems");
            DropTable("Comments");
        }
    }
}
