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
using InsuranceManager.SqlRepository.PolicyByCustomer;
using PolicyByCustomer = InsuranceManager.Domain.PolicyByCustomer;

namespace InsuranceManager.Controllers.Api
{
    /// <summary>
    /// Controller for the PoliciesByCustomer operations
    /// </summary>
    public class PoliciesByCustomerController : ApiController
    {
        private IPolicyByCustomerRepository policyByCustomerRepository;

        public PoliciesByCustomerController()
        {
            policyByCustomerRepository = IocConfig.GetInstance<PolicyByCustomerRepository>();
        }

        [HttpGet]
        public IHttpActionResult GetPoliciesByCustomer(int id)
        {
            return Ok(policyByCustomerRepository.GetPoliciesByCustomer(id).ToList());
        }

        //[HttpGet]
        //public IHttpActionResult GetPoliciesNotInCustomer(int customerId, string not)
        //{
        //    return Ok(policyByCustomerRepository.GetPoliciesNotInCustomer(customerId).ToList());
        //}

        [HttpPost]
        public IHttpActionResult CreatePolicyByCustomer(PolicyByCustomerDto policyByCustomerDto)
        {
            var policyByCustomer = Mapper.Map<PolicyByCustomerDto, PolicyByCustomer>(policyByCustomerDto);
            policyByCustomerRepository.CreatePolicyByCustomer(policyByCustomer);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeletePolicyByCustomer(int id)
        {
            policyByCustomerRepository.DeletePolicyByCustomer(id);
            return Ok();
        }

    }
}
