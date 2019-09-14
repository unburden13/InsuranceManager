﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InsuranceManager.Dtos
{
    public class PolicyDto
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