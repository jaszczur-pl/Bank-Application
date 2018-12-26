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

    }
}