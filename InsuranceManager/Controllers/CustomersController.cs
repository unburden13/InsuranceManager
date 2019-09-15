using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceManager.Controllers
{
    public class CustomersController : Controller
    {

        public Dictionary<string, string> customerData { get; set; }

        public CustomersController()
        {
            customerData = new Dictionary<string, string>();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id, string customerName)
        {
            customerData.Add("CustomerId", id.ToString());
            customerData.Add("CustomerName", customerName);

            return View("PoliciesByCustomerForm", customerData);
        }
    }
}