using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Domain;

namespace InsuranceManager.Contract
{
    public interface IPolicyRepository
    {
        IEnumerable<Policy> GetPolicies();

        Policy GetPolicy(int id);

        int CreatePolicy(Policy policy);

        void UpdatePolicy(Policy policy);

        void DeletePolicy(int id);
    }
}
