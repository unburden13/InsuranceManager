using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Contract;

namespace InsuranceManager.SqlRepository.TypeOfRisk
{
    public class TypeOfRiskRepository : BaseRepository<Domain.TypeOfRisk>, ITypeOfRiskRepository
    {
        public List<Domain.TypeOfRisk> GetTypesOfRisk()
        {
            return GetAll().ToList();
        }

        public Domain.TypeOfRisk GetTypeOfRisk(int id)
        {
            return GetById(id);
        }
    }
}
