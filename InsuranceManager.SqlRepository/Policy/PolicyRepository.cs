using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Contract;
using AutoMapper;

namespace InsuranceManager.SqlRepository.Policy
{
    /// <summary>
    /// Repository to manage the Policy operations in data origin
    /// </summary>
    public class PolicyRepository : BaseRepository<Domain.Policy>, IPolicyRepository
    {
        public IEnumerable<Domain.Policy> GetPolicies()
        {
            return GetAll().ToList();
        }

        public Domain.Policy GetPolicy(int id)
        {
            return GetById(id);
        }

        public int CreatePolicy(Domain.Policy policy)
        {
            Create(policy);
            SaveChanges();
            return policy.Id;
        }

        public void UpdatePolicy(Domain.Policy policy)
        {
            var policyInDb = GetById(policy.Id);
            Mapper.Map(policy, policyInDb);
            SaveChanges();
        }

        public void DeletePolicy(int id)
        {
            var policy = GetById(id);
            Delete(policy);
            SaveChanges();
        }

    }
}
