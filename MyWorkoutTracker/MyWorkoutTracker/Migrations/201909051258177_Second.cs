namespace MyWorkoutTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Years", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Email", c => c.String(nullable: false));
            AddColumn("dbo.People", "Role_Email", c => c.String());
            AddColumn("dbo.People", "Role_SelectedRole", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false));
            DropColumn("dbo.People", "PersonID");
            DropColumn("dbo.People", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.People", "PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            DropColumn("dbo.People", "Role_SelectedRole");
            DropColumn("dbo.People", "Role_Email");
            DropColumn("dbo.People", "Email");
            DropColumn("dbo.People", "Years");
        }
    }
}
