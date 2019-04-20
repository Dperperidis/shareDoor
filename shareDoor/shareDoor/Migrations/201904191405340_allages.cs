namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "Smoker", c => c.String(nullable: false));
            AddColumn("dbo.Houses", "Pets", c => c.String(nullable: false));
            DropColumn("dbo.Houses", "Smoke");
            DropColumn("dbo.Houses", "Animals");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "Animals", c => c.String(nullable: false));
            AddColumn("dbo.Houses", "Smoke", c => c.String(nullable: false));
            DropColumn("dbo.Houses", "Pets");
            DropColumn("dbo.Houses", "Smoker");
        }
    }
}
