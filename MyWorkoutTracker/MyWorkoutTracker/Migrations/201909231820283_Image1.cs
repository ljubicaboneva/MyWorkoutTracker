namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PicUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PicUrl");
        }
    }
}
