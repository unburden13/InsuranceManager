using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InsuranceManager.Dtos;
using AutoMapper;
using InsuranceManager.App_Start;
using InsuranceManager.Contract;
using InsuranceManager.SqlRepository.Customer;
using Customer = InsuranceManager.Domain.Customer;

namespace InsuranceManager.Controllers.Api
{
    /// <summary>
    /// Controller for Customers operations
    /// </summary>
    public class CustomersController : ApiController
    {

        private ICustomerRepository customerRepository;

        public CustomersController()
        {
            customerRepository = IocConfig.GetInstance<CustomerRepository>();
        }

        //GET api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(customerRepository.GetCustomers().Select(Mapper.Map<Customer, CustomerDto>));
        }
    }
}
