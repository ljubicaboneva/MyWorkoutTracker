namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodimages : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Kcal", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Kcal", c => c.Int(nullable: false));
        }
    }
}
