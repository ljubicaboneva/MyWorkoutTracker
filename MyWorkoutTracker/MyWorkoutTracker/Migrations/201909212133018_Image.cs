namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Image_ImageID", "dbo.Images");
            DropIndex("dbo.People", new[] { "Image_ImageID" });
            DropColumn("dbo.People", "Image_ImageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Image_ImageID", c => c.Int());
            CreateIndex("dbo.People", "Image_ImageID");
            AddForeignKey("dbo.People", "Image_ImageID", "dbo.Images", "ImageID");
        }
    }
}
