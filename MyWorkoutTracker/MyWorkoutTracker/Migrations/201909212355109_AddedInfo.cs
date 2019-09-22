namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Info", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Info");
        }
    }
}
