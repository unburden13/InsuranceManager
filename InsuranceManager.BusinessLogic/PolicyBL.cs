using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Domain;
using InsuranceManager.SqlRepository.TypeOfRisk;
using InsuranceManager.Contract;


namespace InsuranceManager.BusinessLogic
{
    /// <summary>
    /// Business logic for Policiy operations
    /// </summary>
    public class PolicyBL
    {
        public int HighTypeOfRisk = 1;
        
        public string CoverageByPolicyCanBeCreated(Domain.Policy policy)
        {
            //var typeOfRiskRepository = new TypeOfRiskRepository();
            //var highTypeOfRiskId = typeOfRiskRepository.GetAll().Where(r => r.Name == "High").SingleOrDefault().Id;
            var coverageByPolicy = policy.CoveragesByPolicy[0];

            if (policy.TypeOfRisk.Name == "High" && coverageByPolicy.Percentage > 50)
                return "The type of risk is 'High', so the coverage percentage can't be major than 50%";

            return "";

        }

    }
}
