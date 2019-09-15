using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManager.Domain
{
    [Table("CoveragesByPolicies")]
    public class CoverageByPolicy
    {
        public int Id { get; set; }

        public Policy Policy { get; set; }
        public int PolicyId { get; set; }

        public Coverage Coverage { get; set; }
        public int CoverageId { get; set; }

        public decimal Percentage { get; set; }
    }
}
