using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using InsuranceManager.Models;
using InsuranceManager.Domain;
using InsuranceManager.SqlRepository;
using InsuranceManager.BusinessLogic;

namespace InsuranceManager.App_Start
{
    public class IocConfig
    {
        public static IContainer container { get; set; }

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //DbContext
            builder.RegisterType<ApplicationDbContext>();
            
            //Domain
            builder.RegisterType<Policy>();
            builder.RegisterType<Coverage>();
            builder.RegisterType<CoverageByPolicy>();
            builder.RegisterType<TypeOfRisk>();
            builder.RegisterType<Customer>();
            builder.RegisterType<PolicyByCustomer>();

            //Repository
            builder.RegisterType<SqlRepository.Policy.PolicyRepository>();
            builder.RegisterType<SqlRepository.Coverage.CoverageRepository>();
            builder.RegisterType<SqlRepository.CoverageByPolicy.CoverageByPolicyRepository>();
            builder.RegisterType<SqlRepository.TypeOfRisk.TypeOfRiskRepository>();
            builder.RegisterType<SqlRepository.Customer.CustomerRepository>();
            builder.RegisterType<SqlRepository.PolicyByCustomer.PolicyByCustomerRepository>();

            //Business Logic
            builder.RegisterType<BusinessLogic.PolicyBL>();

            container = builder.Build();

        }

        public static T GetInstance<T>()
        {
            return container.Resolve<T>();
        }

    }
}