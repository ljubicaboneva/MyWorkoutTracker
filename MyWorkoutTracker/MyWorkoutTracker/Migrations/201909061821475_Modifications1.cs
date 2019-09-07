namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifications1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Role", c => c.String());
        }
    }
}
