namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfasdfads : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "IsConfirmed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "IsConfirmed", c => c.Boolean(nullable: false));
        }
    }
}
