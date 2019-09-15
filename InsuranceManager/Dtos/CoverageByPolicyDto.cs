using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceManager.Dtos
{
    public class CoverageByPolicyDto
    {
        public int Id { get; set; }
        public int PolicyId { get; set; }

        public int CoverageId { get; set; }

        public decimal Percentage { get; set; }
    }
}