namespace TimeManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            CreateIndex("dbo.Person", "User_Id");
            AddForeignKey("dbo.Person", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Users", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Login", c => c.String());
            DropForeignKey("dbo.Person", "User_Id", "dbo.Users");
            DropIndex("dbo.Person", new[] { "User_Id" });
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Person", "User_Id");
        }
    }
}
