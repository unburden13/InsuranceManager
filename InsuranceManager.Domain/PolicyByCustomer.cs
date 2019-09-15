using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManager.Domain
{
    public class PolicyByCustomer
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Policy Policy { get; set; }
        public int PolicyId { get; set; }

        public bool Cancelled { get; set; }
    }
}
