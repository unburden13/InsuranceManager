using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using InsuranceManager.Models;
using InsuranceManager.Dtos;
using AutoMapper;

namespace InsuranceManager.Controllers.Api
{
    public class PoliciesController : ApiController
    {
        public ApplicationDbContext _context;

        public PoliciesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET api/policies
        public IHttpActionResult GetPolicies()
        {
            return Ok(_context.Policies
                .Include(p => p.TypeOfRisk)
                .ToList()
                .Select(Mapper.Map<Policy, PolicyDto>));
        }

        // GET api/policies/1
        public IHttpActionResult GetPolicy(int id)
        {
            var policy = _context.Policies.SingleOrDefault(m => m.Id == id);
            
            if (policy == null)
                return NotFound();

            policy.CoveragesByPolicy = _context.CoveragesByPolicy
                .Where(c => c.PolicyId.Equals(id))
                .ToList();

            return Ok(Mapper.Map<Policy, PolicyDto>(policy));
        }

        // POST api/policies
        [HttpPost]
        public IHttpActionResult CreatePolicy(PolicyDto policyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var policy = Mapper.Map<PolicyDto, Policy>(policyDto);

            _context.Policies.Add(policy);
            _context.SaveChanges();

            policyDto.Id = policy.Id;

            foreach(var detailCoverage in policyDto.CoveragesByPolicy)
            {
                var coveragesByPolicy = Mapper.Map<CoveragesByPolicyDto, CoveragesByPolicy>(detailCoverage);
                coveragesByPolicy.PolicyId = policyDto.Id;
                _context.CoveragesByPolicy.Add(coveragesByPolicy);
            }
            _context.SaveChanges();


            return Created(new Uri(Request.RequestUri + "/" + policy.Id), policyDto);
        }

        // PUT api/policies/1
        [HttpPut]
        public IHttpActionResult UpdatePolicy(int id, PolicyDto policyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var policyInDb = _context.Policies.SingleOrDefault(p => p.Id == id);

            Mapper.Map(policyDto, policyInDb);

            _context.SaveChanges();

            return Ok();

        }

        //DELETE api/policies/1
        public IHttpActionResult DeletePolicy(int id)
        {
            var policyInDb = _context.Policies.SingleOrDefault(p => p.Id == id);

            if (policyInDb == null)
                return NotFound();

            _context.Policies.Remove(policyInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
