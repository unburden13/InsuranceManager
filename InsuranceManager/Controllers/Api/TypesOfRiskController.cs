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
    public class TypesOfRiskController : ApiController
    {
        public ApplicationDbContext _context;

        public TypesOfRiskController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET api/coverages
        public IHttpActionResult GetTypesOfRisk ()
        {
            return Ok(_context.TypesOfRisk
                .ToList()
                .Select(Mapper.Map<TypeOfRisk, TypeOfRiskDto>));
        }

    }
}
