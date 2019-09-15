using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManager.SqlRepository.PolicyByCustomer
{
    [Table("PoliciesByCustomers")]
    public class PolicyByCustomer
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int PolicyId { get; set; }

        public bool Canelled { get; set; }

    }
}
