using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Domain;

namespace InsuranceManager.Contract
{
    public interface IPolicyByCustomerRepository
    {
        
        List<PolicyByCustomer> GetPoliciesByCustomer(int customerId);

        List<Policy> GetPoliciesNotInCustomer(int customerId);

        void CreatePolicyByCustomer(PolicyByCustomer policyByCustomer);

        void DeletePolicyByCustomer(int poilcyByCustomerId);

    }
}
