using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsuranceManager.Models;
using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.ViewModels
{
    public class PolicyFormViewModel
    {

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display (Name = "Coverage Period (In Months)")]
        public short CoveragePeriod { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int TypeOfRiskId { get; set; }

        public IEnumerable<TypeOfRisk> TypeOfRisk { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Policy" : "New Policy";
            }
        }

        public PolicyFormViewModel()
        {
            Id = 0;
        }

        public PolicyFormViewModel(Policy policy)
        {
            Id = policy.Id;
            Name = policy.Name;
            Description = policy.Description;
            StartDate = policy.StartDate;
            CoveragePeriod = policy.CoveragePeriod;
            Price = policy.Price;
            TypeOfRiskId = policy.TypeOfRiskId;
        }

    }
}