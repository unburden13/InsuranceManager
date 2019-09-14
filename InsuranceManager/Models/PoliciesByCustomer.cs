using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceManager.Models
{
    public class PoliciesByCustomer
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public Policy Policy { get; set; }
        public int PolicyId { get; set; }

        public bool Cancelled { get; set; }

    }
}