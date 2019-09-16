using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using InsuranceManager.Models;

namespace InsuranceManager.Controllers
{
    /// <summary>
    /// Manages the redirection to the views of Policies
    /// </summary>
    public class PoliciesController : Controller
    {

        // GET: Policies
        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.CanManagePolicies))
                return View("Index");

            return View("ReadOnlyIndex");

        }

        [Authorize(Roles = RoleName.CanManagePolicies)]
        public ActionResult New()
        {
            return View("PolicyForm", 0);
        }

        [Authorize(Roles = RoleName.CanManagePolicies)]
        public ActionResult Edit(int id)
        {
            return View("PolicyForm", id);
        }

    }
}