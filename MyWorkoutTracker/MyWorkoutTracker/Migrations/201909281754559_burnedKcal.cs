namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class burnedKcal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "burnedKcal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "burnedKcal");
        }
    }
}
