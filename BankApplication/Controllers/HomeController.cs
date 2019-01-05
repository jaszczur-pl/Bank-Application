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
        private CustomerDBContext customerDB = new CustomerDBContext();

        // GET: Home
        public ActionResult Index()
        {
            var customers = from c in customerDB.Customers
                            select c;
            return View(customers);
        }

        public ActionResult Transfer() {
            return View();
        }

        public ActionResult History() {
            var transactions = from t in customerDB.Payments
                               select t;

            return View(transactions);
        }

        public ActionResult Card() {
            
            var cards = from c in customerDB.Cards
                        from cust in customerDB.Customers
                        where c.CustomerID == cust.CustomerID 
                        && c.IsActive == true
                        select c;
            return View(cards);
        }

    }
}