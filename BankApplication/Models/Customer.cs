using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApplication.Models
{
    public class Customer {
        [DisplayName("User ID")]
        [Key]
        [Required]
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public int IncorrectLogins { get; set; }

        public ICollection<Payment> Payments {get; set;}
        public ICollection<Card> Cards { get; set; }
    }

    public class CustomerDBContext: DbContext {
        public CustomerDBContext() { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}