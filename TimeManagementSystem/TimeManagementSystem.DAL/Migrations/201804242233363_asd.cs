namespace TimeManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Person", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "IdUser", c => c.Int(nullable: false));
        }
    }
}
