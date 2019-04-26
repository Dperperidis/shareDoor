namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "Smoker", c => c.String());
            AlterColumn("dbo.Houses", "Pets", c => c.String());
            AlterColumn("dbo.Houses", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "Pets", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "Smoker", c => c.String(nullable: false));
        }
    }
}
