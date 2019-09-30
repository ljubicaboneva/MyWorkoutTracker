namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Foods", "Count");
            DropColumn("dbo.Foods", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "IsSelected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Foods", "Count", c => c.Int(nullable: false));
        }
    }
}