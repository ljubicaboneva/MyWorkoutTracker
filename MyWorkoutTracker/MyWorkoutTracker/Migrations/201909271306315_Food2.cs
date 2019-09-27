namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Food2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Description", c => c.String());
            AddColumn("dbo.Foods", "Kcal", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Foods", "PicUrl", c => c.String());
            DropColumn("dbo.Exercises", "Added");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "Added", c => c.String());
            DropColumn("dbo.Foods", "PicUrl");
            DropColumn("dbo.Foods", "Count");
            DropColumn("dbo.Foods", "Kcal");
            DropColumn("dbo.Foods", "Description");
        }
    }
}
