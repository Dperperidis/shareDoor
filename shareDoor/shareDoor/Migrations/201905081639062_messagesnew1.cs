namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesnew1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageInfoes", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessageInfoes", "Subject");
        }
    }
}
