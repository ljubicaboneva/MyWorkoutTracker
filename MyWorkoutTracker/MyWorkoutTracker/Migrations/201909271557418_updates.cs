namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodPersons",
                c => new
                    {
                        Food_id = c.Int(nullable: false),
                        Person_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Food_id, t.Person_id })
                .ForeignKey("dbo.Foods", t => t.Food_id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_id, cascadeDelete: true)
                .Index(t => t.Food_id)
                .Index(t => t.Person_id);
            
            AddColumn("dbo.Foods", "Food_id", c => c.Int());
            CreateIndex("dbo.Foods", "Food_id");
            AddForeignKey("dbo.Foods", "Food_id", "dbo.Foods", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodPersons", "Person_id", "dbo.People");
            DropForeignKey("dbo.FoodPersons", "Food_id", "dbo.Foods");
            DropForeignKey("dbo.Foods", "Food_id", "dbo.Foods");
            DropIndex("dbo.FoodPersons", new[] { "Person_id" });
            DropIndex("dbo.FoodPersons", new[] { "Food_id" });
            DropIndex("dbo.Foods", new[] { "Food_id" });
            DropColumn("dbo.Foods", "Food_id");
            DropTable("dbo.FoodPersons");
        }
    }
}
