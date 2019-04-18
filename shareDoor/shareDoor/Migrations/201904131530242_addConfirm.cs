namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConfirm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "IsConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Houses", "IsConfirmed");
        }
    }
}
