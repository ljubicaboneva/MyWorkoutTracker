namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExercise1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "exeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "exeId");
        }
    }
}
