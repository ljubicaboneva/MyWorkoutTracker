namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seven : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "myImage_ImageID", "dbo.Images");
            DropIndex("dbo.People", new[] { "myImage_ImageID" });
            DropColumn("dbo.People", "myImage_ImageID");
            DropTable("dbo.Images");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.People", "myImage_ImageID", c => c.Int());
            CreateIndex("dbo.People", "myImage_ImageID");
            AddForeignKey("dbo.People", "myImage_ImageID", "dbo.Images", "ImageID");
        }
    }
}