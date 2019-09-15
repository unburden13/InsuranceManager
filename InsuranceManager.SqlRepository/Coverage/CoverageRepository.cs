using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManager.Contract;

namespace InsuranceManager.SqlRepository.Coverage
{
    public class CoverageRepository : BaseRepository<Domain.Coverage>, ICoverageRepository
    {
        public List<Domain.Coverage> GetCoverages()
        {
            return GetAll().ToList();
        }
    }
}
