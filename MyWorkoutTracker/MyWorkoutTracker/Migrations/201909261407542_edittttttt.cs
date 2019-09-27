namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittttttt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercises", "Person_id", "dbo.People");
            DropIndex("dbo.Exercises", new[] { "Person_id" });
            DropColumn("dbo.Exercises", "Person_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "Person_id", c => c.Int());
            CreateIndex("dbo.Exercises", "Person_id");
            AddForeignKey("dbo.Exercises", "Person_id", "dbo.People", "id");
        }
    }
}
