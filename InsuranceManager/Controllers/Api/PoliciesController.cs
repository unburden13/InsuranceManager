using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsuranceManager.Dtos;
using AutoMapper;
using InsuranceManager.App_Start;
using InsuranceManager.Contract;
using InsuranceManager.SqlRepository.Policy;
using InsuranceManager.SqlRepository.CoverageByPolicy;
using Policy = InsuranceManager.Domain.Policy;
using CoverageByPolicy = InsuranceManager.Domain.CoverageByPolicy;

namespace InsuranceManager.Controllers.Api
{
    /// <summary>
    /// Controller for the policies CRUD
    /// </summary>
    public class PoliciesController : ApiController
    {
        private IPolicyRepository policyRepository;
        private ICoverageByPolicyRepository coverageByPolicyRepository;

        public PoliciesController()
        {
            policyRepository = IocConfig.GetInstance<PolicyRepository>();
            coverageByPolicyRepository = IocConfig.GetInstance<CoverageByPolicyRepository>();
        }

        // GET api/policies
        public IHttpActionResult GetPolicies()
        {
            return Ok(policyRepository.GetPolicies().Select(Mapper.Map <Policy, PolicyDto>));
        }

        // GET api/policies/1
        public IHttpActionResult GetPolicy(int id)
        {
            var policy = policyRepository.GetPolicy(id);

            if (policy == null)
                return NotFound();

            var coveragesByPolicy = coverageByPolicyRepository.GetCoveragesByPolicy(id);

            policy.CoveragesByPolicy = coveragesByPolicy.ToList();

            return Ok(Mapper.Map<Policy, PolicyDto>(policy));
        }

        // POST api/policies
        [HttpPost]
        public IHttpActionResult CreatePolicy(PolicyDto policyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var policy = Mapper.Map<PolicyDto, Policy>(policyDto);

            policy.Id = policyRepository.CreatePolicy(policy);

            return Ok(policy.Id);
        }

        // PUT api/policies/1
        [HttpPut]
        public IHttpActionResult UpdatePolicy(int id, PolicyDto policyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var policyInDb = policyRepository.GetPolicy(id);
            if (policyInDb == null)
                return NotFound();

            Mapper.Map(policyDto, policyInDb);
            policyRepository.UpdatePolicy(policyInDb);

            return Ok();
        }

        //DELETE api/policies/1
        [HttpDelete]
        public IHttpActionResult DeletePolicy(int id)
        {
            var policyInDb = policyRepository.GetPolicy(id);

            if (policyInDb == null)
                return NotFound();

            policyRepository.DeletePolicy(id);

            return Ok();
        }

    }
}
