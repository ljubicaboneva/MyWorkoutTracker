namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExercise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "Added", c => c.String());
            DropColumn("dbo.Exercises", "isSelected");
            DropColumn("dbo.Exercises", "isChecked");
            DropColumn("dbo.People", "exeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "exeId", c => c.Int(nullable: false));
            AddColumn("dbo.Exercises", "isChecked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exercises", "isSelected", c => c.Boolean(nullable: false));
            DropColumn("dbo.Exercises", "Added");
        }
    }
}
