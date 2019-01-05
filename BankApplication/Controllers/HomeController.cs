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
        private PaymentDBContext paymentDB = new PaymentDBContext();
        private CardDBContext cardDB = new CardDBContext();

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
            var transactions = from t in paymentDB.Payments
                               select t;
            return View(transactions);
        }

        public ActionResult Card() {
            var cards = from c in cardDB.Cards
                        select c;
            return View(cards);
        }

    }
}