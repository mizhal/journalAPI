namespace Journal2API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("Comments", "ClassName", c => c.String(unicode: false));
            AddColumn("Comments", "ObjectId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Comments", "ObjectId");
            DropColumn("Comments", "ClassName");
        }
    }
}
