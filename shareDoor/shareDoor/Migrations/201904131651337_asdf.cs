namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Houses", "ApplicationUser_Id");
            AddForeignKey("dbo.Houses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Houses", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Houses", "ApplicationUser_Id");
        }
    }
}
