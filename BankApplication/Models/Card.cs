using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankApplication.Models
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public bool IsActive { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }

}