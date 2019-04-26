namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Smoker", c => c.String());
            AddColumn("dbo.AspNetUsers", "Pets", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserDescription");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Pets");
            DropColumn("dbo.AspNetUsers", "Smoker");
        }
    }
}
