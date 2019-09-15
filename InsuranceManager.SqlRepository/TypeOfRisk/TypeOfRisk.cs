using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManager.SqlRepository.TypeOfRisk
{
    [Table("TypeOfRisks")]
    public class TypeOfRisk
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
