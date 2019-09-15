using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Domain;

namespace InsuranceManager.Contract
{
    public interface ICoverageByPolicyRepository
    {
        void CreateCoverageByPolicy(CoverageByPolicy coverageByPolicy);

        void CreateRangeCoveragesByPolicy(List<CoverageByPolicy> coveragesByPolicy);

        List<CoverageByPolicy> GetCoveragesByPolicy(int policyId);

    }
}
