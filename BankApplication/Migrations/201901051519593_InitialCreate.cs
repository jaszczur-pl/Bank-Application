namespace BankApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Password = c.String(),
                        AccountNumber = c.String(),
                        Balance = c.Double(nullable: false),
                        IncorrectLogins = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        BeneficiaryAccount = c.String(),
                        Title = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Cards", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Payments", new[] { "CustomerID" });
            DropIndex("dbo.Cards", new[] { "CustomerID" });
            DropTable("dbo.Payments");
            DropTable("dbo.Cards");
            DropTable("dbo.Customers");
        }
    }
}
