using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace InsuranceManager.Controllers
{
    public class PoliciesController : Controller
    {

        // GET: Policies
        public ActionResult Index()
        {
            return View(0);
        }

        public ActionResult New()
        {
            return View("PolicyForm", 0);
        }

        public ActionResult Edit(int id)
        {
            return View("PolicyForm", id);
        }

    }
}