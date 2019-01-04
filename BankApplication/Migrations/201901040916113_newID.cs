namespace BankApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "ID", c => c.String(nullable: false, maxLength: 8));
            AddPrimaryKey("dbo.Customers", "ID");
        }
    }
}
