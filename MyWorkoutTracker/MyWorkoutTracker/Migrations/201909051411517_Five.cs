namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Five : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false));
        }
    }
}