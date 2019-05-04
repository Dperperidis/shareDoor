namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "SquareMeters", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "SquareMeters", c => c.Int(nullable: false));
        }
    }
}
