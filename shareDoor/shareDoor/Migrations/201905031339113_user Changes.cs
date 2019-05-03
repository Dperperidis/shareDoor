namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HousePhotoes", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.HousePhotoes", "House_Id", "dbo.Houses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HousePhotoes", "House_Id", "dbo.Houses");
            AddForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.HousePhotoes", "House_Id", "dbo.Houses", "Id");
        }
    }
}
