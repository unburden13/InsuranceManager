using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using InsuranceManager.Models;
using InsuranceManager.Domain;
using InsuranceManager.SqlRepository;


namespace InsuranceManager.App_Start
{
    public class IocConfig
    {
        public static IContainer container { get; set; }

        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ApplicationDbContext>();
            builder.RegisterType<Policy>();
            builder.RegisterType<Coverage>();
            builder.RegisterType<CoverageByPolicy>();
            builder.RegisterType<TypeOfRisk>();
            builder.RegisterType<Customer>();
            builder.RegisterType<PolicyByCustomer>();

            builder.RegisterType<SqlRepository.Policy.PolicyRepository>();
            builder.RegisterType<SqlRepository.Coverage.CoverageRepository>();
            builder.RegisterType<SqlRepository.CoverageByPolicy.CoverageByPolicyRepository>();
            builder.RegisterType<SqlRepository.TypeOfRisk.TypeOfRiskRepository>();

            container = builder.Build();

        }

        public static T GetInstance<T>()
        {
            return container.Resolve<T>();
        }

    }
}