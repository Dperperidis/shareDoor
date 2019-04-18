namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "Description", c => c.String(nullable: false));
        }
    }
}
