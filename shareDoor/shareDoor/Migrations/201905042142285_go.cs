namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "YearConstruct", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "YearConstruct", c => c.DateTime(nullable: false));
        }
    }
}
