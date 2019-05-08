namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageInfoes", "IsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessageInfoes", "IsRead");
        }
    }
}
