namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isSelected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foods", "IsSelected");
        }
    }
}
