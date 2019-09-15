using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InsuranceManager.Domain;

namespace InsuranceManager.SqlRepository
{
    public partial class Context : DbContext
    {
        public Context() : base("name=DefaultConnection")
        {

        }

        public DbSet<Domain.Policy> Policies { get; set; }

        public DbSet<Domain.TypeOfRisk> TypesOfRisk { get; set; }

        public DbSet<Domain.Coverage> Coverages { get; set; }

        public DbSet<Domain.CoverageByPolicy> CoveragesByPolicy { get; set; }

        public DbSet<Domain.Customer> Customers { get; set; }

        public DbSet<Domain.PolicyByCustomer> PoliciesByCustomers { get; set; }

    }

}
