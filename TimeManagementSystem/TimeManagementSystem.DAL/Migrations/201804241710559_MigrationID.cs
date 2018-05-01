namespace TimeManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "IdUser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "IdUser");
        }
    }
}
