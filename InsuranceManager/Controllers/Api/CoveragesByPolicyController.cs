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
using InsuranceManager.SqlRepository.CoverageByPolicy;
using InsuranceManager.Contract;

namespace InsuranceManager.Controllers.Api
{
    /// <summary>
    /// Manages operations and validations of a Coverage in a Policy
    /// </summary>
    public class CoveragesByPolicyController : ApiController
    {

        
        private PolicyBL policyBL { get; set; }

        private ITypeOfRiskRepository typeOfRiskRepository { get; set; }
        private ICoverageByPolicyRepository coverageByPolicyRepository { get; set; }

        public CoveragesByPolicyController()
        {
            policyBL = IocConfig.GetInstance<PolicyBL>();
            typeOfRiskRepository = IocConfig.GetInstance<TypeOfRiskRepository>();
            coverageByPolicyRepository = IocConfig.GetInstance<CoverageByPolicyRepository>();
        }

        [HttpPost]
        public IHttpActionResult CreateCoverageByPolicy(PolicyDto policyDto)
        {
            var policy = Mapper.Map<PolicyDto, Policy>(policyDto);
            var typeOfRisk = typeOfRiskRepository.GetTypeOfRisk(policy.TypeOfRiskId);
            policy.TypeOfRisk = typeOfRisk;

            var coverageByPolicyNoCreationReason = policyBL.CoverageByPolicyCanBeCreated(policy);

            if (coverageByPolicyNoCreationReason != "")
                return BadRequest(coverageByPolicyNoCreationReason);

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteCoverageByPolicy(int id)
        {
            coverageByPolicyRepository.DeleteCoverageByPolicy(id);
            return Ok();
        }

    }
}
