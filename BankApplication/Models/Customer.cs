using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApplication.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public bool IsBlocked { get; set; }
        public int IncorrectLogins { get; set; }
    }
}