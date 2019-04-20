namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatever1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HousePhotoes", "Url", c => c.String());
            AddColumn("dbo.UserPhotoes", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPhotoes", "Url");
            DropColumn("dbo.HousePhotoes", "Url");
        }
    }
}
