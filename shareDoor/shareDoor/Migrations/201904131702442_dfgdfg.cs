namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfgdfg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Houses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Houses", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.Houses", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Houses", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Houses", "UserId");
            AddForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Houses", new[] { "UserId" });
            AlterColumn("dbo.Houses", "UserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Houses", name: "UserId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.Houses", "ApplicationUser_Id");
            AddForeignKey("dbo.Houses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
