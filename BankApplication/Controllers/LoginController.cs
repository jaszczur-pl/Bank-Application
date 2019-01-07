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

                var selectedCustomer = db.Customers.Where(c => c.CustomerID == (int)customer.CustomerID).FirstOrDefault();

                if (!ModelState.IsValid) {
                    return View("Index", customer);
                }
                else {
                    if (selectedCustomer == null) {
                        ModelState.AddModelError("CustomerID", "Customer doesn't exist");
                        return View("Index");
                    }
                    else {

                        bool isAccountBlocked = CheckIfAccountIsBlocked(selectedCustomer);

                        if (isAccountBlocked) {
                            ModelState.AddModelError("CustomerID", "Account has been blocked");
                            return View("Index");
                        }
                        else {

                            var selectedCustomerWithPassword = db.Customers.Where(c => c.CustomerID == customer.CustomerID && c.Password == customer.Password).FirstOrDefault();

                            if (selectedCustomerWithPassword == null) {
                                selectedCustomer.IncorrectLogins += 1;
                                db.SaveChanges();
                                ModelState.AddModelError("CustomerID", "Incorrect login/password");
                                return View("Index");
                            }
                            else {
                                selectedCustomer.IncorrectLogins = 0;
                                db.SaveChanges();
                                Session["userID"] = selectedCustomer.CustomerID;
                                return RedirectToAction("Index", "Home");
                            }
                        }
                    }
                }
            }
        }

        public ActionResult Logout() {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public bool CheckIfAccountIsBlocked(Customer cust) {

            bool isAccountBlocked = false;

            int incorrectLogins = cust.IncorrectLogins;

            if (incorrectLogins >= 3) {
                isAccountBlocked = true;
            }

            return isAccountBlocked;
        }
    }
}