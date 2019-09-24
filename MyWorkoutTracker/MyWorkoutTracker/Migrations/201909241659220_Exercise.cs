namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exercise : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        isSelected = c.Boolean(nullable: false),
                        Person_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.Person_id)
                .Index(t => t.Person_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "Person_id", "dbo.People");
            DropIndex("dbo.Exercises", new[] { "Person_id" });
            DropTable("dbo.Exercises");
        }
    }
}
