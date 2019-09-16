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
        [TestCase("High", 60)]
        [TestCase("High", 30)]
        [TestCase("Low", 10)]
        [TestCase("Low", 80)]
        public void CoverageByPolicyCanBeCreated_WhenCalled_ValidateTypeOfRiskVsPercentage(string typeOfRiskName, decimal coveragePercentage)
        {
            var typeOfRisk = new TypeOfRisk { Name = typeOfRiskName };
            var coverageByPolicy = new CoverageByPolicy { Percentage = coveragePercentage };
            var coveragesByPolicy = new List<CoverageByPolicy>();
            coveragesByPolicy.Add(coverageByPolicy);
            var policy = new Policy { TypeOfRisk = typeOfRisk, CoveragesByPolicy = coveragesByPolicy };

            var result = BL.CoverageByPolicyCanBeCreated(policy);

            if (typeOfRiskName == "High" && coveragePercentage > 50)
                Assert.That(result, Is.Not.EqualTo(""));
            else
                Assert.That(result, Is.EqualTo(""));
        }
    }
}
