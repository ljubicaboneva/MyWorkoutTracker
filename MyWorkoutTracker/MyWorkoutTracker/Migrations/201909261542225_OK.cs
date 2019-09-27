namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonExercises",
                c => new
                    {
                        Person_id = c.Int(nullable: false),
                        Exercise_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_id, t.Exercise_id })
                .ForeignKey("dbo.People", t => t.Person_id, cascadeDelete: true)
                .ForeignKey("dbo.Exercises", t => t.Exercise_id, cascadeDelete: true)
                .Index(t => t.Person_id)
                .Index(t => t.Exercise_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonExercises", "Exercise_id", "dbo.Exercises");
            DropForeignKey("dbo.PersonExercises", "Person_id", "dbo.People");
            DropIndex("dbo.PersonExercises", new[] { "Exercise_id" });
            DropIndex("dbo.PersonExercises", new[] { "Person_id" });
            DropTable("dbo.PersonExercises");
        }
    }
}
