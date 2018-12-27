using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankApplication.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public double Amount { get; set; }
        public string BeneficiaryAccount { get; set; }
        public string Title { get; set; }
    }

    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext() { }
        public DbSet<Card> Payments { get; set; }
    }
}