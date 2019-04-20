namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agjkhadjflkahg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "Smoke", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "Animals", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "Animals", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Houses", "Smoke", c => c.Boolean(nullable: false));
        }
    }
}
