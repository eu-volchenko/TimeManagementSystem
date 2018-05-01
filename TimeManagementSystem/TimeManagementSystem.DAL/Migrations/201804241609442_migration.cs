namespace TimeManagementSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "Surname", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "Surname", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
    }
}
