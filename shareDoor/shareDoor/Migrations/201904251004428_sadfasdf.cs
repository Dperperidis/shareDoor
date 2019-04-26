namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadfasdf : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserPhotoes", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.UserPhotoes", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserPhotoes", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.UserPhotoes", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
