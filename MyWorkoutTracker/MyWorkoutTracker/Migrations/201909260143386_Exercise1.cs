namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exercise1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "isChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "isChecked");
        }
    }
}
