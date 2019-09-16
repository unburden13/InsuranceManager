using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsuranceManager.Domain;
using InsuranceManager.Dtos;
using AutoMapper;
using InsuranceManager.BusinessLogic;
using InsuranceManager.App_Start;
using InsuranceManager.SqlRepository.TypeOfRisk;
using InsuranceManager.Contract;

namespace InsuranceManager.Controllers.Api
{
    /// <summary>
    /// Validates the creation/assignment of a single Coverage in a Policy
    /// </summary>
    public class CoveragesByPolicyController : ApiController
    {

        
        private PolicyBL policyBL { get; set; }

        private ITypeOfRiskRepository repository { get; set; }

        public CoveragesByPolicyController()
        {
            policyBL = IocConfig.GetInstance<PolicyBL>();
            repository = IocConfig.GetInstance<TypeOfRiskRepository>();
        }

        [HttpPost]
        public IHttpActionResult CreateCoverageByPolicy(PolicyDto policyDto)
        {

            var policy = Mapper.Map<PolicyDto, Policy>(policyDto);
            var coverageByPolicyNoCreationReason = policyBL.CoverageByPolicyCanBeCreated(policy);

            if (coverageByPolicyNoCreationReason != "")
                return BadRequest(coverageByPolicyNoCreationReason);

            return Ok();

        }
    }
}
