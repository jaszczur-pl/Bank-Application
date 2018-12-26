using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BankApplication.Models
{
    public class Customer
    {
        [DisplayName("User ID")]
        [MaxLength(8)]
        public string ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public bool IsBlocked { get; set; }
        public int IncorrectLogins { get; set; }

    }

    public class CustomerDBContext: DbContext {
        public CustomerDBContext() { }
        public DbSet<Customer> Customers { get; set; }
    }
}