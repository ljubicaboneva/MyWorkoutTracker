namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seven3 : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.People", "Role_id", c => c.Int());
            CreateIndex("dbo.People", "Role_id");
            AddForeignKey("dbo.People", "Role_id", "dbo.AddToRoleModels", "id");
            DropColumn("dbo.People", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Role", c => c.String());
            DropForeignKey("dbo.People", "Role_id", "dbo.AddToRoleModels");
            DropIndex("dbo.People", new[] { "Role_id" });
            DropColumn("dbo.People", "Role_id");
            DropTable("dbo.AddToRoleModels");
        }
    }
}
