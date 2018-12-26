using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankApplication.Models;

namespace BankApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(Customer customer) {

            using(CustomerDBContext db = new CustomerDBContext()) {

                var selectedCustomer = db.Customers.Where(c => c.ID == customer.ID).FirstOrDefault();

                if (selectedCustomer == null) {
                    return HttpNotFound("Customer doesn't exist");

                }
                else {

                    var selectedCustomerWithPassword = db.Customers.Where(c => c.ID == customer.ID && c.Password == customer.Password).FirstOrDefault();

                    if (selectedCustomerWithPassword == null) {
                        selectedCustomer.IncorrectLogins += 1;
                        db.SaveChanges();
                        return View("Index");
                    }
                    else {
                        Session["userID"] = selectedCustomer.ID;
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
            }
        }

        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        //public bool IsAccountBlocked(Customer cust) {


        //}
    }
}