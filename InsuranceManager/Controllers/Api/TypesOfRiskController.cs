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
using InsuranceManager.Contract;
using InsuranceManager.SqlRepository.TypeOfRisk;
using TypeOfRisk = InsuranceManager.Domain.TypeOfRisk;

namespace InsuranceManager.Controllers.Api
{
    public class TypesOfRiskController : ApiController
    {
        private ITypeOfRiskRepository typeOfRiskRepository;
        
        // GET api/coverages
        public IHttpActionResult GetTypesOfRisk ()
        {

            typeOfRiskRepository = new TypeOfRiskRepository();
            return Ok(typeOfRiskRepository.GetTypesOfRisk()
                .Select(Mapper.Map<TypeOfRisk, TypeOfRiskDto>));
            
        }

    }
}
