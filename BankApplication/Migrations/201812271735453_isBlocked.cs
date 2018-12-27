namespace BankApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isBlocked : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsBlocked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsBlocked", c => c.Boolean(nullable: false));
        }
    }
}
