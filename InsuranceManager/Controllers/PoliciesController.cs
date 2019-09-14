using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using InsuranceManager.Models;
using InsuranceManager.ViewModels;

namespace InsuranceManager.Controllers
{
    public class PoliciesController : Controller
    {

        private ApplicationDbContext _context;

        public PoliciesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Policies
        public ActionResult Index()
        {
            var policies = _context.Policies.Include(p => p.TypeOfRisk).ToList();
            return View(policies);
        }

        public ActionResult New()
        {
            var typesOfRisk = _context.TypesOfRisk.ToList();
            var viewModel = new PolicyFormViewModel {
                TypeOfRisk = typesOfRisk
            };

            return View("PolicyForm", viewModel);
        }

        public ActionResult Save(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PolicyFormViewModel(policy)
                {
                    TypeOfRisk = _context.TypesOfRisk.ToList()
                };

                return View("PolicyForm", viewModel);
            }

            if (policy.Id == 0)
            {
                _context.Policies.Add(policy);
            }
            else
            {
                var policyInDb = _context.Policies.Single(m => m.Id == policy.Id);

                policyInDb.Name = policy.Name;
                policyInDb.Description = policy.Description;
                policyInDb.StartDate = policy.StartDate;
                policyInDb.CoveragePeriod = policy.CoveragePeriod;
                policyInDb.Price = policy.Price;
                policyInDb.TypeOfRiskId = policy.TypeOfRiskId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Policies");
        }

        public ActionResult Edit(int id)
        {
            var policy = _context.Policies.SingleOrDefault(p => p.Id == id);

            if (policy == null)
                return HttpNotFound();

            var viewModel = new PolicyFormViewModel(policy)
            {
                TypeOfRisk = _context.TypesOfRisk.ToList()
            };

            return View("PolicyForm", viewModel);

        }

    }
}