namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        SenderId = c.String(maxLength: 128),
                        ReceiverId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageInfoes", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageInfoes", "ReceiverId", "dbo.AspNetUsers");
            DropIndex("dbo.MessageInfoes", new[] { "ReceiverId" });
            DropIndex("dbo.MessageInfoes", new[] { "SenderId" });
            DropTable("dbo.MessageInfoes");
        }
    }
}
