using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManager.SqlRepository.Policy
{
    
    [Table("Policies")]
    public partial class Policy
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public short CoveragePeriod { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int TypeOfRiskId { get; set; }
        
    }
}
