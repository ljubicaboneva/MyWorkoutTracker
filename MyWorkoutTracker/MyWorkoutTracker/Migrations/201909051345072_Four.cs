namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Role_id", "dbo.AddToRoleModels");
            DropIndex("dbo.People", new[] { "Role_id" });
            DropColumn("dbo.People", "Role_id");
            DropTable("dbo.AddToRoleModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AddToRoleModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        SelectedRole = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.People", "Role_id", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "Role_id");
            AddForeignKey("dbo.People", "Role_id", "dbo.AddToRoleModels", "id", cascadeDelete: true);
        }
    }
}
