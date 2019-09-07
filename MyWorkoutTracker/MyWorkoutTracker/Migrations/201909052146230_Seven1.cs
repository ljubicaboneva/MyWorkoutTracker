namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seven1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Role", c => c.String());
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Email", c => c.String());
            DropColumn("dbo.People", "Role");
        }
    }
}
