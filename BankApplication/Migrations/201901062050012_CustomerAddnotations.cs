namespace BankApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAddnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String());
        }
    }
}
