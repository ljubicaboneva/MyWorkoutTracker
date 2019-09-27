namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PicUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "PicUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exercises", "PicUrl");
        }
    }
}
