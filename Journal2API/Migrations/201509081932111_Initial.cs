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
                        Title = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Description = c.String(maxLength: 4098, storeType: "nvarchar"),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Position = c.Int(nullable: false),
                        State_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("WorkflowStates", t => t.State_Id, cascadeDelete: true)
                .Index(t => t.State_Id);
            
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
                .Index(t => new { t.Name, t.Workflow_Id });
            
            CreateTable(
                "Workflows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64, storeType: "nvarchar"),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)                
                .Index(t => t.Name, unique: true);
            
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
                .Index(t => new { t.Destination_Id, t.Origin_Id, t.Workflow_Id });
            
            CreateTable(
                "TodoItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Position = c.Int(nullable: false),
                        Parent_Id = c.Int(),
                        State_Id = c.Int(),
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
                    Id = c.Int(nullable: false, identity: true),
                    ClassName = c.String(maxLength: 128, storeType: "nvarchar"),
                    Workflow_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Workflows", t => t.Workflow_Id)
                .Index(t => new { t.ClassName, t.Workflow_Id }, unique: true, name: "IX_Definition");
            
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
