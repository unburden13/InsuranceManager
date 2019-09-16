using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Domain;

namespace InsuranceManager.Contract
{
    public interface ITypeOfRiskRepository
    {
        List<TypeOfRisk> GetTypesOfRisk();

        TypeOfRisk GetTypeOfRisk(int id);
    }
}
