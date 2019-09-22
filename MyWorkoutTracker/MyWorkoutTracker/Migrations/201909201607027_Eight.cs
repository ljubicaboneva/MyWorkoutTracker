namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Role");
        }
    }
}
