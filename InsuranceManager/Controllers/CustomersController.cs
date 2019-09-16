using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceManager.Models;

namespace InsuranceManager.Controllers
{
    /// <summary>
    /// Manages the redirection to the views of Customers
    /// </summary>
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
            if (User.IsInRole(RoleName.CanManagePolicies))
                return View("Index");

            return View("ReadOnlyIndex");

        }

        public ActionResult Edit(int id, string customerName)
        {
            customerData.Add("CustomerId", id.ToString());
            customerData.Add("CustomerName", customerName);

            if (User.IsInRole(RoleName.CanManagePolicies))
                return View("PoliciesByCustomerForm", customerData);

            return View("PoliciesByCustomerReadOnly", customerData);
        }
    }
}