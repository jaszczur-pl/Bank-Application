﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankApplication.Models
{
    public class Card
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public bool IsActive { get; set; }
    }

    public class CardDBContext : DbContext
    {
        public CardDBContext() { }
        public DbSet<Card> Cards { get; set; }
    }
}