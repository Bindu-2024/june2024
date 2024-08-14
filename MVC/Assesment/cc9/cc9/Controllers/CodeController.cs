using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cc9.Models;

namespace cc9.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities1 db = new northwindEntities1();

        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }
        public ActionResult CustomerByOrderId(int? orderId)
        {
            if (orderId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var customerDetails = db.Orders
                             .Where(o => o.OrderID == orderId)
                             .Select(o => o.Customer)
                             .FirstOrDefault();

            if (customerDetails == null)
            {
                return HttpNotFound();
            }
            return View(customerDetails);
        }

    }
        
}
