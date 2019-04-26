namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Houses", new[] { "UserId" });
            AlterColumn("dbo.Houses", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Houses", "UserId");
            AddForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Houses", new[] { "UserId" });
            AlterColumn("dbo.Houses", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Houses", "UserId");
            AddForeignKey("dbo.Houses", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
