using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Contract;

namespace InsuranceManager.SqlRepository.Customer
{
    /// <summary>
    /// Repository to manage the Customer operations in data origin
    /// </summary>
    public class CustomerRepository : BaseRepository<Domain.Customer>, ICustomerRepository
    {
        public IEnumerable<Domain.Customer> GetCustomers()
        {
            return GetAll().ToList();
        }



    }
}
