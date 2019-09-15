using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Contract;
using System.Linq.Expressions;

namespace InsuranceManager.SqlRepository.CoverageByPolicy
{
    /// <summary>
    /// Repository to manage the operations in data origin for Coverage By Policy 
    /// </summary>
    public class CoverageByPolicyRepository : BaseRepository<Domain.CoverageByPolicy>, ICoverageByPolicyRepository
    {
        public void CreateCoverageByPolicy(Domain.CoverageByPolicy coverageByPolicy)
        {
            Create(coverageByPolicy);
            SaveChanges();
        }

        public void CreateRangeCoveragesByPolicy(List<Domain.CoverageByPolicy> coveragesByPolicy)
        {
            CreateRange(coveragesByPolicy);
            SaveChanges();
        }

        public List<Domain.CoverageByPolicy> GetCoveragesByPolicy(int policyId)
        {
            Expression<Func<Domain.CoverageByPolicy, bool>> expression = c => c.PolicyId == policyId;
            return Filter(expression).AsQueryable().ToList();
        }

    }
}
