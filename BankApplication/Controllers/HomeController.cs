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
        [HttpGet]
        public ActionResult Index()
        {
            int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);

            var customers = from c in customerDB.Customers
                            where c.CustomerID == userID
                            select c;
            return View(customers);
        }

        public ActionResult Transfer() {
            return View();
        }

        [HttpGet]
        public ActionResult History() {

            int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);

            var transactions = from tran in customerDB.Payments
                               where tran.CustomerID == userID
                               select tran;

            return View(transactions);
        }

        public ActionResult Card() {

            int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);

            var cards = from card in customerDB.Cards
                        where card.CustomerID == userID
                        && card.IsActive == true
                        select card;
            return View(cards);
        }

        public ActionResult OrderCard() {
            int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);

            using (CustomerDBContext db = new CustomerDBContext()) {
                Card newCard = new Card {
                    IsActive = true,
                    CustomerID = userID
                };

                db.Cards.Add(newCard);
                db.SaveChanges();
            }

            return RedirectToAction("Card");
        }

        public ActionResult DeactivateCard() {
            int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);

            using (CustomerDBContext db = new CustomerDBContext()) {
                var cards = from c in db.Cards
                            where c.CustomerID == userID
                            select c;

                foreach (Card card in cards) {
                    card.IsActive = false;
                }

                db.SaveChanges();
            }

            return RedirectToAction("Card");
        }

        [HttpPost]
        public ActionResult MakeTransfer(Payment payment) {
            int userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);

            using (CustomerDBContext db = new CustomerDBContext()) {
                var customer = from c in db.Customers
                               where c.CustomerID == userID
                               select c;

                if(payment.Amount > customer.First().Balance) {
                    return HttpNotFound("Transfer amount exceeds balance");
                }
                else {
                    customer.First().Balance -= payment.Amount;
                    payment.CustomerID = userID;
                    db.Payments.Add(payment);
                    db.SaveChanges();
                    ModelState.Clear();
                }
            }

            return View("Transfer");
        }
    }
}