using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankApplication.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public double Amount { get; set; }
        public string BeneficiaryAccount { get; set; }
        public string Title { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }

    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext() { }
        public DbSet<Card> Payments { get; set; }
    }
}