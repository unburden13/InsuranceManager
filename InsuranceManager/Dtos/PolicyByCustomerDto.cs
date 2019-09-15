using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceManager.Dtos
{
    public class PolicyByCustomerDto
    {
        public int Id { get; set; }

        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }

        public PolicyDto Policy { get; set; }
        public int PolicyId { get; set; }

        public bool Cancelled { get; set; }

    }
}