namespace BankApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentAddnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "BeneficiaryAccount", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Title", c => c.String());
            AlterColumn("dbo.Payments", "BeneficiaryAccount", c => c.String());
        }
    }
}
