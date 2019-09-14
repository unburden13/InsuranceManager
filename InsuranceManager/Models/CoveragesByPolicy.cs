using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceManager.Models
{
    public class CoveragesByPolicy
    {
        public int Id { get; set; }

        public Policy Policy { get; set; }
        public int PolicyId { get; set; }

        public Coverage Coverage { get; set; }
        public int CoverageId { get; set; }

        public decimal Percentage { get; set; }

    }
}