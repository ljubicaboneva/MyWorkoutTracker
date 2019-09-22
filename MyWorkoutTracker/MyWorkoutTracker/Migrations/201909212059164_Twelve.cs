namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Twelve : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            AddColumn("dbo.People", "Image_ImageID", c => c.Int());
            CreateIndex("dbo.People", "Image_ImageID");
            AddForeignKey("dbo.People", "Image_ImageID", "dbo.Images", "ImageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Image_ImageID", "dbo.Images");
            DropIndex("dbo.People", new[] { "Image_ImageID" });
            DropColumn("dbo.People", "Image_ImageID");
            DropTable("dbo.Images");
        }
    }
}
