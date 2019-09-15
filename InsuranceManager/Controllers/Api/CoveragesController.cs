using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsuranceManager.Domain;
using InsuranceManager.Dtos;
using AutoMapper;
using InsuranceManager.Contract;
using InsuranceManager.SqlRepository.Coverage;
using Coverage = InsuranceManager.Domain.Coverage;


namespace InsuranceManager.Controllers.Api
{
    public class CoveragesController : ApiController
    {

        private ICoverageRepository coverageRepository;

        // GET api/coverages
        public IHttpActionResult GetCoverages()
        {
            coverageRepository = new CoverageRepository();
            var coverages = coverageRepository.GetCoverages();

            return Ok(coverageRepository.GetCoverages()
                .Select(Mapper.Map<Coverage, CoverageDto>));
            
        }

    }
}
