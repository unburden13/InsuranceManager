using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Contract;
using System.Linq.Expressions;
using AutoMapper;

namespace InsuranceManager.SqlRepository.PolicyByCustomer
{
    /// <summary>
    /// Repository to manage the operations in data origin for Policies By Customer
    /// </summary>
    public class PolicyByCustomerRepository : BaseRepository<Domain.PolicyByCustomer>, IPolicyByCustomerRepository
    {
        
        public List<Domain.PolicyByCustomer> GetPoliciesByCustomer(int customerId)
        {
            Expression<Func<Domain.PolicyByCustomer, bool>> expression = c => c.CustomerId == customerId;
            var policiesByCustomer = Filter(expression).AsQueryable().ToList();

            var policyBase = new BaseRepository<Domain.Policy>();
            foreach (var policyByCustomer in policiesByCustomer)
            {
                var policy = policyBase.GetById(policyByCustomer.PolicyId);
                policyByCustomer.Policy = policy;
            }

            return policiesByCustomer;

        }

        public List<Domain.Policy> GetPoliciesNotInCustomer(int customerId)
        {
            var policyBase = new BaseRepository<Domain.Policy>();
            var policies = policyBase.GetAll();

            Expression<Func<Domain.PolicyByCustomer, bool>> expression = c => c.CustomerId == customerId;
            var policiesByCustomer = Filter(expression).AsQueryable().ToList();

            var policiesNotInCustomer = policies.Where(p => !policiesByCustomer.Any(pc => pc.Id == p.Id)).AsEnumerable().ToList();
            return policiesNotInCustomer;
        }

        public void CreatePolicyByCustomer(Domain.PolicyByCustomer policyByCustomer)
        {
            Create(policyByCustomer);
            SaveChanges();
        }

        public void DeletePolicyByCustomer(int poilcyByCustomerId)
        {
            var policyBycustomer = GetById(poilcyByCustomerId);
            Delete(policyBycustomer);
            SaveChanges();
        }

    }
}
