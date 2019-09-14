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
    public class CoveragesController : ApiController
    {
        public ApplicationDbContext _context;

        public CoveragesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET api/coverages
        public IHttpActionResult GetCoverages()
        {
            return Ok(_context.Coverages
                .ToList()
                .Select(Mapper.Map<Coverage, CoverageDto>));
        }

    }
}
