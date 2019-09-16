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
    public class PolicyBL
    {
        public int HighTypeOfRisk = 1;
        //public PolicyBL()
        //{
        //    var typeOfRiskRepository = new TypeOfRiskRepository();
        //    HighTypeOfRisk = typeOfRiskRepository.GetAll().Where(r => r.Name == "High").SingleOrDefault().Id;
        //}

        public string CoverageByPolicyCanBeCreated(Domain.Policy policy)
        {
            //var typeOfRiskRepository = new TypeOfRiskRepository();
            //var typeOfRisk = typeOfRiskRepository.GetById(policy.TypeOfRiskId);

            //var typeOfRisk = repository.GetTypeOfRisk(policy.TypeOfRiskId);
            var coverageByPolicy = policy.CoveragesByPolicy[0];

            if (policy.TypeOfRiskId == HighTypeOfRisk && coverageByPolicy.Percentage > 50)
                return "The type of risk is 'High', so the coverage percentage can't be major than 50%";

            return "";

        }

    }
}
