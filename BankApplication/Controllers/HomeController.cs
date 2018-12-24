using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApplication.Models;

namespace BankApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var customers = from c in Customers()
                            select c;
            return View(customers);
        }

        public List<Customer> Customers() {
            return new List<Customer> {
                new Customer {
                ID = 1000,
                Name = "Jan",
                Surname = "Kowalski",
                Password = "1234",
                AccountNumber = "100",
                Balance = 123412.00,
                IsBlocked = false,
                IncorrectLogins = 0
                }

            };
        }
    }
}