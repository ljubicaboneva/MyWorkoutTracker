namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Weight", c => c.Int(nullable: false));
            DropColumn("dbo.People", "exeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "exeId", c => c.Int(nullable: false));
            DropColumn("dbo.People", "Weight");
        }
    }
}
