using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using InsuranceManager.Domain;
using InsuranceManager.BusinessLogic;
using InsuranceManager.Contract;
using InsuranceManager.SqlRepository;

namespace InsuranceManager.Tests
{
    [TestFixture]
    public class PolicyBLTests
    {
        private PolicyBL BL;

        [SetUp]
        public void Setup()
        {
            BL = new PolicyBL();
        }

        [Test]
        [TestCase(1, 60)]
        [TestCase(1, 30)]
        public void TestMethod1(int typeOfRiskId, decimal coveragePercentage)
        {
            //var repositoryTypeOfRisk = new SqlRepository.TypeOfRisk.TypeOfRiskRepository();
            //var highTypeOfRisk = repositoryTypeOfRisk.GetAll().Where(r => r.Name == "High").SingleOrDefault().Id;
            //var highTypeOfRiskId = 1;

            //var repository = new Mock<ITypeOfRiskRepository>();
            //repository.Setup(r => r.GetTypeOfRisk(typeOfRiskId)).Returns(new TypeOfRisk());

            var coverageByPolicy = new CoverageByPolicy { Percentage = coveragePercentage };
            var coveragesByPolicy = new List<CoverageByPolicy>();
            coveragesByPolicy.Add(coverageByPolicy);
            var policy = new Policy { TypeOfRiskId = typeOfRiskId, CoveragesByPolicy = coveragesByPolicy };

            var result = BL.CoverageByPolicyCanBeCreated(policy);

            if (typeOfRiskId == BL.HighTypeOfRisk && coveragePercentage > 50)
                Assert.That(result, Is.Not.EqualTo(""));
            else
                Assert.That(result, Is.EqualTo(""));

        }
    }
}
