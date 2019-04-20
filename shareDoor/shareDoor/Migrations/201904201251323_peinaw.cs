namespace shareDoor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class peinaw : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "RentCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "RentCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
